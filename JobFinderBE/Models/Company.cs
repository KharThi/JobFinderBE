using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class Company
    {
        public Company()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Logo { get; set; }
        public string AboutCompany { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
