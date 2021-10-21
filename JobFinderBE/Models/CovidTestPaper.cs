using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class CovidTestPaper
    {
        public int Id { get; set; }
        public string TestType { get; set; }
        public string TestResult { get; set; }
        public DateTime? Date { get; set; }
        public string Image { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
