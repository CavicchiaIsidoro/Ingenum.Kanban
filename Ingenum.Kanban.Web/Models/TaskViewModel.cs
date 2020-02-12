using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ingenum.Kanban.Web.Models
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string Intitule { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date de fin")]
        public DateTime? EndDate { get; set; }
        public SectionEnum Section { get; set; }
        public virtual BoardViewModel Board { get; set; }
        public int BoardId { get; set; }
    }

    public enum SectionEnum
    {
        TODO,
        DOING,
        DONE
    }
}
