using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanHang.Models
{
    public class AccountUser
    {
        public tblAccount Account { get; set; }
        public tblUser User { get; set; }
    }
}