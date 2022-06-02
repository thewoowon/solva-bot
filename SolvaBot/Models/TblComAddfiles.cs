using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SolvaBot.Models
{
    public partial class TblComAddfiles
    {
        public string Code { get; set; } = string.Empty;
        public string CompanyCode { get; set; } = string.Empty;
        public string Pcode { get; set; } = string.Empty;
        public string Fn { get; set; } = string.Empty;
        public string OriginFn { get; set; } = string.Empty;
        public string Floc { get; set; } = string.Empty;
        public long Fsize { get; set; }
        public string Fext { get; set; } = string.Empty;
        public int Role { get; set; }
        public DateTime Wdate { get; set; }
    }
}
