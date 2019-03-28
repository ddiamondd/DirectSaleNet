using System;
using System.Collections.Generic;

namespace DirectSaleNet.Models
{
    public partial class Manufactor
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ContactTel { get; set; }
        public DateTime? RegistDate { get; set; }
        public string Status { get; set; }
    }
}
