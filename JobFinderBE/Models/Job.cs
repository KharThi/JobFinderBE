using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class Job
    {
        public Job()
        {
            MarkJobs = new HashSet<MarkJob>();
            UserJobs = new HashSet<UserJob>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Sallary { get; set; }
        public int? CompanyId { get; set; }
        public string Image { get; set; }
        public string MainCriteria { get; set; }
        public string JobOpportunity { get; set; }
        public string Employee { get; set; }
        public string CovidPassport { get; set; }
        public string WorkingPlace { get; set; }
        public string SalaryDescription { get; set; }
        public string WorkingTimeDescription { get; set; }
        public string WorkingTime { get; set; }
        public string SalaryDetail { get; set; }
        public string JobResponsbilities { get; set; }
        public string Tag { get; set; }
        public string JobName { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<MarkJob> MarkJobs { get; set; }
        public virtual ICollection<UserJob> UserJobs { get; set; }
    }
}
