namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblWebsiteLink")]
    public partial class tblWebsiteLink
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Url { get; set; }

        [Required]
        [StringLength(150)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedUser { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedUser { get; set; }
    }
}
