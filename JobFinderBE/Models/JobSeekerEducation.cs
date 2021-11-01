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
        public string SchoolName { get; set; }
        public string Majors { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public bool? IsStillStudying { get; set; }

        public virtual User User { get; set; }
    }
}
