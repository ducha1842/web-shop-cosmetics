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

        /// <summary>
        /// Get list product by ProductType
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public  List<tblProduct> ListByCategoryId(long categoryID)
        {
            return db.tblProducts.Where(x => x.ProductType == categoryID).ToList();
        }
    }
}