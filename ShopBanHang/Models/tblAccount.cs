namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAccount")]
    public partial class tblAccount
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string AccountName { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        public DateTime? DateIssued { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedUser { get; set; }
    }
}
