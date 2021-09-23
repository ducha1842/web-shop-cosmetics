using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers.Customer
{
    public class CustomerController : Controller
    {
        WebShopDbContext db;
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string AccountName, string Password)
        {
            db = new WebShopDbContext();
            var NameUser = db.tblAccounts.Where(x => x.AccountName == AccountName && x.Password == Password).FirstOrDefault();
            if (NameUser != null)
            {
                Session["NameUser"] = NameUser;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["NameUser"] = null;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}