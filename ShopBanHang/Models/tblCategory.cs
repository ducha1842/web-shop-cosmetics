namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCategory")]
    public partial class tblCategory
    {
        public int ID { get; set; }

        public int ParentID { get; set; }

        [Required]
        [StringLength(100)]
        public string CateName { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        public int OrderNumber { get; set; }

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
