using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class UserJob
    {
        public int? UserId { get; set; }
        public int? JobId { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public int Id { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
