using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class JobSeekerWorkExperience
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Skill { get; set; }
        public string Experience { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public bool? IsStillWorking { get; set; }

        public virtual User User { get; set; }
    }
}
