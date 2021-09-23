using ShopBanHang.Dao;
using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(long cateId)
        {
            //var model = db.tblProductCategories.Find(id);
            var category = new CategoryDao().ViewDetail(cateId);
            return View(category);
        }

        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }

        public ActionResult AddToCart(int Id, string Name, string ImageUrl, string Price, int Quantity)
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
                item.Quantity = Quantity;
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
                        item.Quantity = item.Quantity + Quantity;
                        bCheck = true;
                        break;
                    }
                }
                if (bCheck == false)
                {
                    var item = new CartItem();
                    item.Id = Id;
                    item.Name = Name;
                    item.Quantity = Quantity;
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
            return RedirectToAction("Index", "Cart");
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
            return RedirectToAction("Index", "Cart");
        }
    }
}