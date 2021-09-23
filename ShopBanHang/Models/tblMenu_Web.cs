namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblMenu_Web
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? CategoryID { get; set; }

        public int? ParentID { get; set; }

        public int? TypeMenu { get; set; }

        public int? OrderNumber { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(250)]
        public string Page { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        public int? Status { get; set; }
    }
}
