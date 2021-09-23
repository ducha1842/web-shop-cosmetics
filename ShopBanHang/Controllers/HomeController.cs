using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanHang.Models;

namespace ShopBanHang.Controllers
{
    public class HomeController : Controller
    {
        #region db
        WebShopDbContext db = new WebShopDbContext();
        #endregion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MenuHeader()
        {
            var model = db.tblMenu_Web.Where(x => x.Status == 1).OrderBy(x => x.OrderNumber).ToList();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult SearchformProduct()
        {
            var model = db.tblProductCategories.Where(x => x.Status == 1 && x.ShowOnHome == 1).OrderBy(x => x.DisplayOrder).ToList();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Slider()
        {
            var model = db.tblSlides.Where(x => x.Status == 1).OrderBy(x => x.DisplayOrder).Take(3).ToList();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult ProductCategory()
        {
            var model = db.tblProductCategories.Where(x => x.Status == 1 && x.ShowOnHome == 1).OrderBy(x => x.DisplayOrder).ToList();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult PopularProduct()
        {
            //var model = (from a in db.tblProducts
            //             join b in db.tblProductPrices
            //             on a.ProductID equals b.ProductID
            //             select new
            //             {
            //                 Id = a.ProductID,
            //                 Name = a.Name,
            //                 ImageUrl = a.ImageUrl,
            //                 ProductType = a.ProductType,
            //                 Sale = b.Sale,
            //                 Price = b.Price,
            //                 PriceSale = b.PriceSale
            //             }).ToList();

            //List<ProductView> _lstProduct = new List<ProductView>();
            //if (model != null && model.Count > 0)
            //{
            //    foreach (var item in model)
            //    {
            //        ProductView _productView = new ProductView();
            //        _productView._Product = new tblProduct();
            //        _productView._ProductPrice = new tblProductPrice();

            //        _productView._Product.ProductID = item.Id;
            //        _productView._Product.Name = item.Name;
            //        _productView._Product.ImageUrl = item.ImageUrl;
            //        _productView._Product.ProductType = item.ProductType;
            //        _productView._ProductPrice.Sale = item.Sale;
            //        _productView._ProductPrice.Price = item.Price;
            //        _productView._ProductPrice.PriceSale = item.PriceSale;
            //        _lstProduct.Add(_productView);
            //    }
            //}
            var model = db.tblProducts.Where(x => x.Status == 1).OrderBy(x => x.ProductID).ToList();
            return PartialView(model);
        }

        public ActionResult AddToCart (int Id, string Name, string ImageUrl, string Price)
        {
            Session["TotalProduct"] = 0;
            Session["TotalMoney"] = 0;
            decimal Total = 0;
            //Kiem tra gio hang co null hay khong
            var lstItem = new List<CartItem>();
            if (Session["Cart"] == null) 
            {
                var item = new CartItem();
                item.Id = Id;
                item.Name = Name;
                item.Quantity = 1;
                item.ImageUrl = ImageUrl;
                item.Price = Convert.ToDecimal(Price);
                lstItem.Add(item);
                Session["Cart"] = lstItem;
                Total = Total + item.Quantity * item.Price;
                Session["TotalProduct"] = 1;
                Session["TotalMoney"] = Total;
            }
            else
            {
                //Kiem tra co san pham trong gio hang hay cha => Neu co roi
                // 1: Tang so luong
                // 2: Thiem moi
                lstItem = (List<CartItem>)Session["Cart"];
                bool bCheck = false;
                foreach (var item in lstItem)
                {
                    if (item.Id == Id)
                    {
                        item.Quantity = item.Quantity + 1;
                        bCheck = true;
                        break;
                    }
                }
                if (bCheck == false)
                {
                    var item = new CartItem();
                    item.Id = Id;
                    item.Name = Name;
                    item.Quantity = 1;
                    item.ImageUrl = ImageUrl;
                    item.Price = Convert.ToDecimal(Price);
                    lstItem.Add(item);
                }
                Session["Cart"] = lstItem;

                //Tinh tổng tiền
                foreach (var item in lstItem)
                {
                    Total = Total + item.Quantity * item.Price;
                }
                Session["TotalProduct"] = lstItem.Count;
                Session["TotalMoney"] = Total;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveToCart(int Id)
        {
            decimal Total = 0;
            //Kiem tra gio hang co null hay khong
            var lstItem = (List<CartItem>)Session["Cart"];
            lstItem.RemoveAll(x => x.Id == Id);
            // Gán lại session để tính giá tiền sau khi remove
            Session["Cart"] = lstItem;
            foreach (var item in lstItem)
            {
                Total = Total + item.Quantity * item.Price;
            }
            Session["TotalProduct"] = lstItem.Count;
            Session["TotalMoney"] = Total;
            return RedirectToAction("Index", "Home");
        }
    }
}