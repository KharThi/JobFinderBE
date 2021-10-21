using System;
using System.Collections.Generic;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class CovidPassport
    {
        public int Id { get; set; }
        public int? Level { get; set; }
        public DateTime? _1stInjectionDate { get; set; }
        public DateTime? _2stInjectionDate { get; set; }
        public string Image { get; set; }
        public string QrCode { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
