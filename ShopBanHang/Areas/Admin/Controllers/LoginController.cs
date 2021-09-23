using ShopBanHang.Areas.Admin.Common;
using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        WebShopDbContext db = new WebShopDbContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblAccount model, FormCollection collection)
        {
            var NameUser = db.tblAccounts.Where(x => x.AccountName == model.AccountName && x.Status == 1).FirstOrDefault();
            Session["NameUser"] = NameUser;
            if (Session["NameUser"] == null)
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại";
                return View();
            }
            else
            {
                var item = db.tblAccounts.Where(x => x.AccountName == model.AccountName && x.Password == model.Password && x.Status == 1).FirstOrDefault();
                if (item != null)
                {
                    if (item.DateIssued < DateTime.Now)
                    {
                        var userSession = new UserLogin();
                        userSession.UserID = item.ID;
                        userSession.UserName = item.AccountName;
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", " Tài khoản hết hiệu lực");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin tài khoản hoặc mật khẩu không chính xác");
                    return View();
                }
            }
        }

        public ActionResult Logout()
        {
            var NameUser = db.tblAccounts.FirstOrDefault();
            Session["NameUser"] = NameUser;
            Session.Remove("NameUser");

            return RedirectToAction("Index", "Login");
        }
    }
}