using Abp.AutoMapper;
using LinhDang.KworkPractice.Core.Notebooks;

namespace LinhDang.KworkPractice.Notebooks.Dto
{
    [AutoMapTo(typeof(Note))]
    public class AddNewNoteDto
    {
        public int NotebookId { get; set; }
        public string Content { get; set; }
    }
}