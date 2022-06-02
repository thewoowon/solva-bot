using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SolvaBot.Models
{
    public partial class TblComCompany
    {
        public string CompanyCode { get; set; }
        public DateTime? Wdate { get; set; }
        public string CompanyName { get; set; }
    }
}
