using Abp.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LinhDang.KworkPractice.Web.Models.Notebooks
{
    public class CreateNotebookViewModel
    {
        [Required]
        [StringLength(255,MinimumLength = 1)]
        public string Name { get; set; }
       
    }
}