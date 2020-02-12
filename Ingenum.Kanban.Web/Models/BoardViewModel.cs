using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ingenum.Kanban.Web.Models
{
    public class BoardViewModel
    {
        public int BoardId { get; set; }

        [Display(Name = "Nom du tableau")]
        public string BoardName { get; set; }

        [Display(Name = "Utilisateur")]
        public string Username { get; set; }

        [Display(Name = "Vérouiller")]
        public bool IsLocked { get; set; }

        [Display(Name = "Liste des tâches")]
        public virtual IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();

    }
}
