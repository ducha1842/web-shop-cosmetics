using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBanHang.Models;

namespace ShopBanHang.Dao
{
    public class CategoryDao
    {

        WebShopDbContext db = null;
        public CategoryDao()
        {
            db = new WebShopDbContext();
        }
        public tblProductCategory ViewDetail(long id)
        {
            return db.tblProductCategories.Find(id);
        }


    }
}