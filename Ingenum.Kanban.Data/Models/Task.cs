using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ingenum.Kanban.Data.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Intitule { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? EndDate { get; set; }
        public SectionEnum Section { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
