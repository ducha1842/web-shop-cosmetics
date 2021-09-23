using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class CartController : Controller
    {
        #region db
        WebShopDbContext db = new WebShopDbContext();
        #endregion
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult CheckOutCart(List<CartItem> lstProduct)
        {
            return View();
        }
    }
}