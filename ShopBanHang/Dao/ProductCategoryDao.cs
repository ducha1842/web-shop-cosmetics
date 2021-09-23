using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBanHang.Models;

namespace ShopBanHang.Dao
{
    public class ProductCategoryDao
    {
        WebShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new WebShopDbContext();
        }

        public List<tblProductCategory> ListAll()
        {
            return db.tblProductCategories.Where(x => x.Status == 1).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}