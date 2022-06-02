using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SolvaBot.Models
{
    public partial class TblComDtlcodes
    {
        public string Code { get; set; }
        public string Ymd { get; set; }
        public int Num { get; set; }
        public DateTime Wdate { get; set; }
    }
}
