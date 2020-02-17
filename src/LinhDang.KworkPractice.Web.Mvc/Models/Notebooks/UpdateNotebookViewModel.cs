using Abp.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LinhDang.KworkPractice.Web.Models.Notebooks
{
    public class UpdateNotebookViewModel
    {
        [Required]
        [StringLength(255,MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public int NotebookId { get; set; }
    }
}