using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    public class MenuWebController : Controller
    {
        WebShopDbContext db;
        // GET: Admin/MenuWeb
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = "Danh mục Menu Web";
            db = new WebShopDbContext();
            var model = db.tblMenu_Web.Where(x => x.Status == 1).OrderBy(x => x.ID).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetCombobox();
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblMenu_Web model, FormCollection collection)
        {
            model.TypeMenu = 0;
            model.CategoryID = -1;
            model.ParentID = Convert.ToInt32(collection["cboMenu"].ToString());
            //model.Page = "-1";
            model.MetaTitle = "-1";
            model.Status = 1;
            if (ModelState.IsValid == true)
            {
                db = new WebShopDbContext();
                db.tblMenu_Web.Add(model);
                var result = db.SaveChanges();
                return RedirectToAction("Index", "MenuWeb");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi kiểm tra dữ liệu");
                return View();
            }
        }
        public void SetCombobox()
        {
            db = new WebShopDbContext();
            var model = db.tblMenu_Web.Where(x => x.Status == 1).ToList();
            ViewBag.Menu = model;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetCombobox();
            db = new WebShopDbContext();
            var model = db.tblMenu_Web.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(tblMenu_Web model, FormCollection collection)
        {
            SetCombobox();
            try
            {
                if (ModelState.IsValid == true)
                {
                    db = new WebShopDbContext();
                    var item = db.tblMenu_Web.Find(model.ID);
                    item.Name = model.Name;
                    item.Url = model.Url;
                    if (collection["cboMenu"].ToString().Trim() != "")
                        item.ParentID = Convert.ToInt32(collection["cboMenu"].ToString());
                    else
                        item.ParentID = -1;
                    item.OrderNumber = model.OrderNumber;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "MenuWeb");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                db = new WebShopDbContext();
                var item = db.tblMenu_Web.Find(id);
                if (item != null)
                {
                    db.tblMenu_Web.Remove(item);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MenuWeb");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

    }
}