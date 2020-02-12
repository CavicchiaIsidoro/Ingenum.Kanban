using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ingenum.Kanban.Data.Models
{
    public class Board
    {
        [Key]
        public int BoardId { get; set; }

        [Required]
        [StringLength(50)]
        public string BoardName { get; set; }

        [StringLength(50)]
        public string Username { get; set; }
        public bool IsLocked { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
