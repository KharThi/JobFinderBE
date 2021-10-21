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
        public int? Experience { get; set; }

        public virtual User User { get; set; }
    }
}
