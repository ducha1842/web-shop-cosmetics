namespace ShopBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblModulePanel")]
    public partial class tblModulePanel
    {
        public int ID { get; set; }

        public int PanelName { get; set; }

        public int Location { get; set; }

        public int OrderNumber { get; set; }

        public int IsHome { get; set; }

        public int TypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string ModuleTitle { get; set; }

        [StringLength(150)]
        public string ModuleIcon { get; set; }

        public int Record { get; set; }

        public int Language { get; set; }

        public int Status { get; set; }
    }
}
