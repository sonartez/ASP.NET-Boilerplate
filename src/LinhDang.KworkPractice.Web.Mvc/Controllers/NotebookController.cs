using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Uow;
using Abp.Web.Models;
using LinhDang.KworkPractice.Authorization.Users;
using LinhDang.KworkPractice.Controllers;
using LinhDang.KworkPractice.Notebooks;
using LinhDang.KworkPractice.Notebooks.Dto;
using LinhDang.KworkPractice.Sessions;
using LinhDang.KworkPractice.Web.Models.Notebooks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinhDang.KworkPractice.Web.Mvc.Controllers
{
    public class NotebookController : KworkPracticeControllerBase
    {
        private readonly UserManager _userManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly ISessionAppService _sessionAppService;
        private readonly INotebookAppService _notebookAppService;

        public NotebookController(
            UserManager userManager,
            IUnitOfWorkManager unitOfWorkManager,
            UserRegistrationManager userRegistrationManager,
            ISessionAppService sessionAppService,
            INotebookAppService notebookAppService)
        {
            _userManager = userManager;
            _unitOfWorkManager = unitOfWorkManager;
            _userRegistrationManager = userRegistrationManager;
            _sessionAppService = sessionAppService;
            _notebookAppService = notebookAppService;

        }

        [AbpMvcAuthorize]
        public ActionResult Index(long selected = 0)
        {
            var notebookViewModel = new AllNotebookViewModel();

            var notebooks = _notebookAppService.GetAll();

            if (notebooks != null && notebooks.Count > 0)
            {
                if (selected <= 0)
                {
                    notebookViewModel.Selected = notebooks[0].Id;
                }
                else
                {
                    if (notebooks.FirstOrDefault(n => n.Id == selected) == null)
                    {
                        notebookViewModel.Selected = notebooks[0].Id;
                    }
                    else
                    {
                        notebookViewModel.Selected = selected;
                    }
                }
            }
            else
            {
                notebookViewModel.Selected = 0;
            }

            var selectedNotebook = notebooks.FirstOrDefault(n => n.Id == notebookViewModel.Selected);
            if (selectedNotebook == null)
            {
                selectedNotebook = new LinhDang.KworkPractice.Notebooks.Dto.NotebookDto()
                { Notes = new List<LinhDang.KworkPractice.Notebooks.Dto.NoteDto>() };
            }
            else
            {
                selectedNotebook.Notes =  _notebookAppService.GetNotes(selectedNotebook.Id);
            }


            return View(new AllNotebookViewModel
            {
                UserId = AbpSession.UserId.Value,
                Notebooks = notebooks,
                DataTime = DateTime.UtcNow,
                Selected = selected,
                SelectedNotebook = selectedNotebook
            });
        }

        [AbpMvcAuthorize]
        [HttpPost]
        public ActionResult CreateNotebook(CreateNotebookViewModel createNotebookViewModel)
        {
            if (!TryValidateModel(createNotebookViewModel))
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Invalid input data"), Success = false });
            }

            AddNewNotebookDto newNotebook = new AddNewNotebookDto()
            {
                Name = createNotebookViewModel.Name,
                UserId = AbpSession.UserId.Value
            };

            var notebook = _notebookAppService.Create(newNotebook);
            if (notebook == null)
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Create new Notebook unsuccessful."), Success = false });
            }

            return Json(new AjaxResponse { Result = notebook });
        }

        [AbpMvcAuthorize]
        [HttpPost]
        public ActionResult UpdateNotebook(UpdateNotebookViewModel updateNotebookViewModel)
        {
            if (!TryValidateModel(updateNotebookViewModel))
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Invalid input data"), Success = false });
            }

            NotebookDto notebook = new NotebookDto()
            {
                Name = updateNotebookViewModel.Name,
                Id = updateNotebookViewModel.NotebookId,
                UserId = AbpSession.UserId.Value
            };

            notebook = _notebookAppService.Update(notebook);
            if (notebook == null)
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Update notebook unsuccessful."), Success = false });
            }

            return Json(new AjaxResponse { Result = notebook });
        }

        [AbpMvcAuthorize]
        [HttpDelete]
        public ActionResult RemoveNotebook(int notebookId)
        {
            if (notebookId <= 0)
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Invalid input data"), Success = false });
            }

            var deleted = _notebookAppService.Remove(notebookId);
            if (!deleted)
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("remove Notebook unsuccessful."), Success = false });
            }

            return Json(new AjaxResponse { Success = deleted, Result = new { notebookId } });
        }


        #region Notes 

        [AbpMvcAuthorize]
        [HttpPost]
        public ActionResult AddNote(AddNewNoteViewModel addNewNoteViewModel)
        {
            if (!TryValidateModel(addNewNoteViewModel))
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Invalid input data"), Success = false });
            }

            AddNewNoteDto newNote = new AddNewNoteDto()
            {
                Content = addNewNoteViewModel.Content,
                NotebookId = addNewNoteViewModel.NotebookId,
            };

            var note = _notebookAppService.AddNote(newNote);
            if (note == null)
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Create new note unsuccessful."), Success = false });
            }

            return Json(new AjaxResponse { Result = note });
        }

        [AbpMvcAuthorize]
        [HttpPost]
        public ActionResult UpdateNote(UpdateNoteViewModel updateNoteViewModel)
        {
            if (!TryValidateModel(updateNoteViewModel))
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Invalid input data"), Success = false });
            }

            NoteDto note = new NoteDto()
            {
                Content = updateNoteViewModel.Content,
                Id = updateNoteViewModel.NoteId,
                NotebookId = updateNoteViewModel.NotebookId
            };

            note = _notebookAppService.UpdateNote(note);
            if (note == null)
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Update note unsuccessful."), Success = false });
            }

            return Json(new AjaxResponse { Result = note });
        }

        [AbpMvcAuthorize]
        [HttpDelete]
        public ActionResult RemoveNote(int noteId)
        {
            if (noteId <= 0)
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("Invalid input data"), Success = false });
            }

            var deleted = _notebookAppService.RemoveNote(noteId);
            if (!deleted)
            {
                return Json(new AjaxResponse { Error = new ErrorInfo("remove Note unsuccessful."), Success = false });
            }

            return Json(new AjaxResponse { Success = deleted, Result = new { noteId } });
        }

        #endregion

    }
}