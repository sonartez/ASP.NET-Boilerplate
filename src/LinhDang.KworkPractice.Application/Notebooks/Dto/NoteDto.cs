using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LinhDang.KworkPractice.Core.Notebooks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinhDang.KworkPractice.Notebooks.Dto
{
    [AutoMapFrom(typeof(Note))]
    public class NoteDto  :EntityDto<int>
    {
        public int NotebookId { get; set; }
        public string Content { get; set; }

        //public virtual NotebookDto Notebook { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
