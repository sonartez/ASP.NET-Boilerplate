using LinhDang.KworkPractice.Notebooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinhDang.KworkPractice.Web.Models.Notebooks
{
    public class AllNotebookViewModel
    {
        public long UserId { get; set; }
        public DateTime DataTime { get; set; }

        public List<NotebookDto> Notebooks { get; set; }
        public long Selected { get; set; }
        public NotebookDto SelectedNotebook { get; internal set; }
    }
}
