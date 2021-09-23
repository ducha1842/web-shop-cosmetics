namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? ProductType { get; set; }

        [StringLength(200)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string MadeIn { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Status { get; set; }

        public decimal? Price { get; set; }

        public decimal? PriceSale { get; set; }

        public int? Sale { get; set; }

        public DateTime? DateIssued { get; set; }

        public int? IsDate { get; set; }    
    }
}
