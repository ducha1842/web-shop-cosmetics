using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopBanHang.Models
{
    public partial class WebShopDbContext : DbContext
    {
        public WebShopDbContext()
            : base("name=WebShopDbContext")
        {
        }

        public virtual DbSet<tblAccount> tblAccounts { get; set; }
        public virtual DbSet<tblAdv> tblAdvs { get; set; }
        public virtual DbSet<tblAlbum> tblAlbums { get; set; }
        public virtual DbSet<tblBanner> tblBanners { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblImage> tblImages { get; set; }
        public virtual DbSet<tblMenu> tblMenus { get; set; }
        public virtual DbSet<tblMenu_Role> tblMenu_Role { get; set; }
        public virtual DbSet<tblMenu_Web> tblMenu_Web { get; set; }
        public virtual DbSet<tblModulePanel> tblModulePanels { get; set; }
        public virtual DbSet<tblNew> tblNews { get; set; }
        public virtual DbSet<tblNews_File> tblNews_File { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductCategory> tblProductCategories { get; set; }
        public virtual DbSet<tblProductPrice> tblProductPrices { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblSlide> tblSlides { get; set; }
        public virtual DbSet<tblTypeModule> tblTypeModules { get; set; }
        public virtual DbSet<tblUnit> tblUnits { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblUser_Role> tblUser_Role { get; set; }
        public virtual DbSet<tblVideo> tblVideos { get; set; }
        public virtual DbSet<tblWebsiteLink> tblWebsiteLinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblImage>()
                .Property(e => e.SizeImage)
                .HasPrecision(18, 3);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.PriceSale)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProductPrice>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProductPrice>()
                .Property(e => e.PriceSale)
                .HasPrecision(18, 0);
        }
    }
}
