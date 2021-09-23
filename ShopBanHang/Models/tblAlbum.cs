namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAlbum
    {
        public int ID { get; set; }

        public int ParentID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime? DateIssued { get; set; }

        [StringLength(100)]
        public string ImageThumb { get; set; }

        [StringLength(100)]
        public string ImageLarge { get; set; }

        public int OrderNumber { get; set; }

        public int Status { get; set; }
    }
}
