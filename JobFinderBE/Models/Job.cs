using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class Job
    {
        public int Id { get; set; }
        public bool Type { get; set; }
        public string Location { get; set; }
        public string Skill { get; set; }
        public int? Experience { get; set; }
        public double Salary { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
