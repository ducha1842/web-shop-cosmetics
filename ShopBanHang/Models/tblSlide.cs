namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSlide")]
    public partial class tblSlide
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string ImageUrl { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        public DateTime? DateIssued { get; set; }

        public int? Status { get; set; }
    }
}
