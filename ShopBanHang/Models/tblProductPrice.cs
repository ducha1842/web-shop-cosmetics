namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductPrice")]
    public partial class tblProductPrice
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public decimal? Price { get; set; }

        public decimal? PriceSale { get; set; }

        public int? Sale { get; set; }

        public DateTime? DateIssued { get; set; }

        public int? IsDate { get; set; }
    }
}
