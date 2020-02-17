using Abp.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LinhDang.KworkPractice.Web.Models.Notebooks
{
    public class AddNewNoteViewModel
    {
        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Content { get; set; }

        [Required]
        public int NotebookId { get; set; }        
    }
}