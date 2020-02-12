using Ingenum.Kaban.Business.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ingenum.Kaban.Business.Models
{
    public class TaskBusiness
    {
        public int TaskId { get; set; }
        public string Intitule { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public SectionEnumBusiness Section { get; set; }
        public int BoardId { get; set; }
    }
}
