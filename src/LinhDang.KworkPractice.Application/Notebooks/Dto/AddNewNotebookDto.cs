using Abp.AutoMapper;
using LinhDang.KworkPractice.Core.Notebooks;
using System;
using System.ComponentModel.DataAnnotations;

namespace LinhDang.KworkPractice.Notebooks.Dto
{
    [AutoMapTo(typeof(Notebook))]
    public class AddNewNotebookDto
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public long UserId { get; set; }
    }
}