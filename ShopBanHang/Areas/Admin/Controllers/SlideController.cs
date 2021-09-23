using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        WebShopDbContext db;
        // GET: Admin/Slide
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = "Danh mục Slide";
            db = new WebShopDbContext();
            var model = db.tblSlides.Where(x => x.Status == 1).OrderBy(x => x.ID).ToList();
            return View(model);
        }
    }
}