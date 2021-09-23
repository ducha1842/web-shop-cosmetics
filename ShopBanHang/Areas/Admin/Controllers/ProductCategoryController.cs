using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        WebShopDbContext db;
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = "Danh mục sản phẩm";
            db = new WebShopDbContext();
            var model = db.tblProductCategories.Where(x => x.Status == 1).OrderBy(x => x.ID).ToList();
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            SetCombobox();
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblProductCategory model, FormCollection collection)
        {
            model.DisplayOrder = 1;
            model.ParentID = Convert.ToInt32(collection["cboCategory"].ToString());
            model.ShowOnHome = Convert.ToInt32(collection["cboShow"].ToString());
            model.Status = 1;
            if (ModelState.IsValid == true)
            {
                db = new WebShopDbContext();
                db.tblProductCategories.Add(model);
                var result = db.SaveChanges();
                return RedirectToAction("Index", "ProductCategory");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi kiểm tra dữ liệu");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetCombobox();
            db = new WebShopDbContext();
            var model = db.tblProductCategories.Find(id);
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
                    var item = db.tblProductCategories.Find(model.ID);
                    item.Name = model.Name;
                    item.MetaTitle = model.MetaTitle;
                    if (collection["cboMenu"].ToString().Trim() != "")
                        item.ParentID = Convert.ToInt32(collection["cboMenu"].ToString());
                    else
                        item.ParentID = -1;
                    if (collection["cboShow"].ToString().Trim() != "")
                        item.ShowOnHome = Convert.ToInt32(collection["cboShow"].ToString());
                    else
                        item.ShowOnHome = -1;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "ProductCategory");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public void SetCombobox()
        {
            db = new WebShopDbContext();
            var model = db.tblProductCategories.Where(x => x.Status == 1).ToList();
            ViewBag.ProductCategory = model;
        }

        public ActionResult Delete(int id)
        {
            try
            {
                db = new WebShopDbContext();
                var item = db.tblProductCategories.Find(id);
                if (item != null)
                {
                    db.tblProductCategories.Remove(item);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "ProductCategory");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}