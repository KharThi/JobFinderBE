using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class JobSeekerEducation
    {
        public int Id { get; set; }
        public string Education { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
