using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class User
    {
        public User()
        {
            CovidPassports = new HashSet<CovidPassport>();
            CovidTestPapers = new HashSet<CovidTestPaper>();
            JobSeekerEducations = new HashSet<JobSeekerEducation>();
            JobSeekerWorkExperiences = new HashSet<JobSeekerWorkExperience>();
            MarkJobs = new HashSet<MarkJob>();
            UserJobs = new HashSet<UserJob>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public bool? Gender { get; set; }
        public int? Age { get; set; }
        public int? Phonenumber { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public int? CitizenIdentification { get; set; }
        public bool? Status { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<CovidPassport> CovidPassports { get; set; }
        public virtual ICollection<CovidTestPaper> CovidTestPapers { get; set; }
        public virtual ICollection<JobSeekerEducation> JobSeekerEducations { get; set; }
        public virtual ICollection<JobSeekerWorkExperience> JobSeekerWorkExperiences { get; set; }
        public virtual ICollection<MarkJob> MarkJobs { get; set; }
        public virtual ICollection<UserJob> UserJobs { get; set; }
    }
}
