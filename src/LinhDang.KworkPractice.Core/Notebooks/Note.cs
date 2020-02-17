using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;

namespace LinhDang.KworkPractice.Core.Notebooks
{
    public class Note : Entity<int>, IAudited
    {
        public int NotebookId { get; set; }
        public string Content { get; set; }

        public virtual Notebook Notebook { get; set; }

        public DateTime CreationTime { get ; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}