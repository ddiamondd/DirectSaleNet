using System;
using System.Collections.Generic;

namespace DirectSaleNet.Models
{
    public partial class User
    {
        public string UserId { get; set; }
        public string Pwd { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public int ManufactorId { get; set; }
    }
}
