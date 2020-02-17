using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LinhDang.KworkPractice.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LinhDang.KworkPractice.Core.Notebooks
{
    public class Notebook : Entity<int>, IAudited
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }

    }
}
