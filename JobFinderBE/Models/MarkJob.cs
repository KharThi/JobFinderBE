using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class MarkJob
    {
        public int? UserId { get; set; }
        public int? JobId { get; set; }
        public int Id { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
