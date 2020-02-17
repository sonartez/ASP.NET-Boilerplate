using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using LinhDang.KworkPractice.Authorization;
using LinhDang.KworkPractice.Authorization.Users;
using LinhDang.KworkPractice.Core.Notebooks;
using LinhDang.KworkPractice.Notebooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinhDang.KworkPractice.Notebooks
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class NotebookAppService : ApplicationService, INotebookAppService
    {
        private readonly UserManager _userManager;
        private readonly IRepository<Notebook, int> _notebookRepository;
        private readonly IRepository<Note, int> _noteRepository;
        private readonly IAbpSession _abpSession;
        private readonly LogInManager _logInManager;

        public NotebookAppService(
            IRepository<Notebook, int> notebookRepository,
            IRepository<Note, int> noteRepository,
            UserManager userManager,
            IAbpSession abpSession,
            LogInManager logInManager)
        {
            _notebookRepository = notebookRepository;
            _noteRepository = noteRepository;
            _userManager = userManager;
            _abpSession = abpSession;
            _logInManager = logInManager;
        }

        #region Notebook

        public NotebookDto Create(AddNewNotebookDto newNotebook)
        {
            try
            {
                var notebook = ObjectMapper.Map<Notebook>(newNotebook);
                notebook.UserId = AbpSession.GetUserId();
                notebook.CreatorUserId = AbpSession.UserId;
                notebook.CreationTime = DateTime.UtcNow;
                notebook = _notebookRepository.Insert(notebook);
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<NotebookDto>(notebook);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return null;
            }

        }

        public NotebookDto Get(int notebookId)
        {
            var notebook = _notebookRepository.FirstOrDefault(p => p.Id == notebookId);
            return ObjectMapper.Map<NotebookDto>(notebook);
        }

        public List<NotebookDto> GetAll()
        {
            if (AbpSession.UserId == null)
            {
                return new List<NotebookDto>();
            }

            var notebooks = _notebookRepository.GetAllList(p => p.UserId == AbpSession.UserId).OrderByDescending(n => n.CreationTime);

            return ObjectMapper.Map<List<NotebookDto>>(notebooks);
        }

        public NotebookDto Update(NotebookDto notebookDto)
        {
            try
            {
                Notebook notebook = CheckOwnerPermission(notebookDto.Id);

                notebook.Name = notebookDto.Name;
                notebook.LastModificationTime = DateTime.UtcNow;
                notebook.LastModifierUserId = AbpSession.UserId;

                notebook = _notebookRepository.Update(notebook);
                CurrentUnitOfWork.SaveChanges();

                return ObjectMapper.Map<NotebookDto>(notebook);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return null;
            }
        }

        public bool Remove(int notebookId)
        {
            try
            {
                Notebook notebook = CheckOwnerPermission(notebookId);

                _notebookRepository.Delete(notebook);
                CurrentUnitOfWork.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        #endregion

        #region Note
        public NoteDto GetNote(int noteId)
        {
            if (AbpSession.UserId == null)
            {
                throw new AbpAuthorizationException();
            }

            var note = _noteRepository.FirstOrDefault(p => p.Id == noteId && p.Notebook.UserId == _abpSession.UserId);
            return ObjectMapper.Map<NoteDto>(note);
        }

        public List<NoteDto> GetNotes(int notebookId)
        {
            if (AbpSession.UserId == null)
            {
                throw new AbpAuthorizationException();
            }

            var notes = _noteRepository.GetAllList(p => p.NotebookId == notebookId && p.Notebook.UserId == _abpSession.UserId);
            return ObjectMapper.Map<List<NoteDto>>(notes);
        }

        public bool RemoveNote(int noteId)
        {
            try
            {
                if (AbpSession.UserId == null)
                {
                    throw new AbpAuthorizationException();
                }

                var note = _noteRepository.FirstOrDefault(p => p.Id == noteId && p.Notebook.UserId == _abpSession.UserId);

                if (note == null)
                {
                    throw new Exception("Note was not existed or access denided!");
                }

                _noteRepository.Delete(note);
                CurrentUnitOfWork.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        public NoteDto AddNote(AddNewNoteDto newNote)
        {
            try
            {
                if (AbpSession.UserId == null)
                {
                    throw new AbpAuthorizationException();
                }

                var note = ObjectMapper.Map<Note>(newNote);

                if (note.NotebookId > 0)
                {
                    var notebook = _notebookRepository.FirstOrDefault(x => x.Id == note.NotebookId);
                    if (notebook == null)
                    {
                        throw new Exception("Notebook was not exist!");
                    }
                }
                else
                {
                    throw new Exception("Note must in a Notebook");
                }

                note.CreatorUserId = AbpSession.UserId;
                note.CreationTime = DateTime.UtcNow;

                note = _noteRepository.Insert(note);
                CurrentUnitOfWork.SaveChanges();

                return ObjectMapper.Map<NoteDto>(note);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return null;
            }
        }

        public NoteDto UpdateNote(NoteDto noteDto)
        {
            try
            {
                if (AbpSession.UserId == null)
                {
                    throw new AbpAuthorizationException();
                }

                if (noteDto.NotebookId > 0)
                {
                    var notebook = _notebookRepository.FirstOrDefault(x => x.Id == noteDto.NotebookId);
                    if (notebook == null)
                    {
                        throw new Exception("Notebook was not exist!");
                    }
                }
                else
                {
                    throw new Exception("Note must in a Notebook");
                }

                var note = _noteRepository.FirstOrDefault(p => p.Id == noteDto.Id && p.NotebookId == noteDto.NotebookId && p.Notebook.UserId == _abpSession.UserId);

                if (note == null)
                {
                    throw new Exception("Note was not existed or access denided!");
                }

                note.Content = noteDto.Content.Trim();
                note.LastModifierUserId = AbpSession.UserId;
                note.LastModificationTime = DateTime.UtcNow;

                note = _noteRepository.Update(note);
                CurrentUnitOfWork.SaveChanges();

                return ObjectMapper.Map<NoteDto>(note);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return null;
            }
        }
        #endregion

        #region privated methods
        private Notebook CheckOwnerPermission(int notebookId)
        {
            if (AbpSession.UserId == null)
            {
                throw new AbpAuthorizationException();
            }

            var notebook = _notebookRepository.FirstOrDefault(p => p.Id == notebookId);

            if (notebook == null)
            {
                throw new KeyNotFoundException();
            }

            if (AbpSession.UserId != notebook.UserId)
            {
                throw new AbpAuthorizationException("Only owner can update/remove notebook.");
            }

            return notebook;
        }

       
        #endregion
    }
}

