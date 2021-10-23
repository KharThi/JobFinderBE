using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class Job
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Skill { get; set; }
        public string Experience { get; set; }
        public string Salary { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
