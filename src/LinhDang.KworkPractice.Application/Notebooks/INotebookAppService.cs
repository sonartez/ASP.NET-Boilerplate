using Abp.Application.Services;
using LinhDang.KworkPractice.Notebooks.Dto;
using System.Collections.Generic;

namespace LinhDang.KworkPractice.Notebooks
{
    public interface INotebookAppService : IApplicationService
    {
        NotebookDto Create(AddNewNotebookDto newNotebook);
        List<NotebookDto> GetAll();
        NotebookDto Get(int notebookId);
        NotebookDto Update(NotebookDto notebook);
        bool Remove(int notebookId);

        NoteDto AddNote(AddNewNoteDto newNote);
        NoteDto GetNote(int noteId);
        List<NoteDto> GetNotes(int notebookId);
        NoteDto UpdateNote(NoteDto note);
        bool RemoveNote(int noteId);

    }
}
