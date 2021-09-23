namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAdv")]
    public partial class tblAdv
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string ImageUrl { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Describle { get; set; }

        public int OrderNumber { get; set; }

        public DateTime DateIssued { get; set; }

        public int TimeIssued { get; set; }

        public int Status { get; set; }
    }
}
