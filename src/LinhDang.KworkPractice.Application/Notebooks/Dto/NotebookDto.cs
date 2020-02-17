using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LinhDang.KworkPractice.Core.Notebooks;
using LinhDang.KworkPractice.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinhDang.KworkPractice.Notebooks.Dto
{
    [AutoMapFrom(typeof(Notebook))]
    public class NotebookDto : EntityDto<int>
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public long UserId { get; set; }
        public virtual UserDto User { get; set; }

        public virtual List<NoteDto> Notes { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
