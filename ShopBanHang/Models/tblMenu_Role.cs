namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblMenu_Role
    {
        public int ID { get; set; }

        public int MenuID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleID { get; set; }
    }
}
