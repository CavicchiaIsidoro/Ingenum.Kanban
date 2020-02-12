using System;
using System.Collections.Generic;
using System.Text;

namespace Ingenum.Kaban.Business.Models
{
    public class BoardBusiness
    {
        public int BoardId { get; set; }
        public string BoardName { get; set; }
        public string Username { get; set; }
        public bool IsLocked { get; set; }
        public IEnumerable<TaskBusiness> Tasks { get; set; } = new List<TaskBusiness>();
    }
}
