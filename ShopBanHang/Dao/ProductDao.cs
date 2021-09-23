using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanHang.Dao
{
    public class ProductDao
    {
        WebShopDbContext db = null;
        public ProductDao()
        {
            db = new WebShopDbContext();
        }
        public tblProduct ViewDetail(long id)
        {
            return db.tblProducts.Find(id);
        }
    }
}