using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        WebShopDbContext db;
        // GET: Admin/User
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = "Người dùng";
            db = new WebShopDbContext();
            var model = (from a in db.tblAccounts
                         where a.Status == 1
                         join b in db.tblUsers
                         on a.ID equals b.Account_ID
                         select new
                         {
                             objAccount = a,
                             objUser = b
                         }
                        ).ToList();

            List<AccountUser> lstAU = new List<AccountUser>();

            foreach (var item in model)
            {
                AccountUser _accountUser = new AccountUser();
                _accountUser.Account = new tblAccount();
                _accountUser.User = new tblUser();
                _accountUser.Account.ID = item.objAccount.ID;
                _accountUser.Account.AccountName = item.objAccount.AccountName;
                _accountUser.User.ImageUrl = item.objUser.ImageUrl;
                _accountUser.User.UserName = item.objUser.UserName;
                _accountUser.User.Sex = item.objUser.Sex;
                _accountUser.User.Birthday = item.objUser.Birthday;
                _accountUser.User.Address = item.objUser.Address;
                _accountUser.User.Phone = item.objUser.Phone;
                _accountUser.User.Email = item.objUser.Email;
                lstAU.Add(_accountUser);
            }
            return View(lstAU);
        }

        [HttpGet]
        public ActionResult Create()
        {
            AccountUser model = new AccountUser();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AccountUser model, HttpPostedFile filePost, FormCollection collection)
        {
            string fileLocation = "";
            if (Request.Files["filePost"].ContentLength <= 0) { model.User.ImageUrl = ""; }
            ModelState["filePost"].Errors.Clear();

            if (ModelState.IsValid == true)
            {
                if (Request.Files["filePost"].ContentLength > 0)
                {
                    string fileExtension = System.IO.Path.GetExtension(Request.Files["filePost"].FileName);
                    fileLocation = Server.MapPath("~/Areas/Admin/assets/images/users/") + Request.Files["filePost"].FileName;

                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["filePost"].SaveAs(fileLocation);
                }
                tblAccount accItem = new tblAccount();
                accItem.AccountName = model.Account.AccountName;
                accItem.CreatedDate = DateTime.Now;
                accItem.CreatedUser = "NguyenDucHa";
                accItem.DateIssued = model.Account.DateIssued;
                accItem.ID = -1;
                accItem.ModifiedDate = DateTime.Now;
                accItem.ModifiedUser = "NguyenDucHa";
                accItem.Password = model.Account.Password;
                accItem.Status = 1;
                WebShopDbContext db = new WebShopDbContext();
                db.tblAccounts.Add(accItem);
                db.SaveChanges();

                tblUser userItem = new tblUser();
                userItem.Account_ID = accItem.ID;
                userItem.Address = model.User.Address;
                userItem.Birthday = model.User.Birthday;
                userItem.Email = model.User.Email;
                userItem.Phone = model.User.Phone;
                userItem.CreatedDate = DateTime.Now;
                userItem.CreatedUser = "NguyenDucHa";
                userItem.Description = model.User.Description;
                userItem.ID = -1;

                int iContent = fileLocation.IndexOf("users") + 6;
                if (iContent > 0)
                {
                    userItem.ImageUrl = fileLocation.Substring(iContent, fileLocation.Length - iContent);
                }

                //userItem.ImageUrl = @"\" + fileLocation;
                userItem.ModifiedDate = DateTime.Now;
                userItem.ModifiedUser = "NguyenDucHa";

                var GioiTinh = collection["customRadio"];
                if (collection["customRadio"].ToString().Trim() != "Nam")
                    userItem.Sex = Convert.ToInt32(collection["customRadio"].ToString());
                else
                    userItem.Sex = 0;

                userItem.Status = 1;
                userItem.UserName = model.User.UserName;
                db.tblUsers.Add(userItem);
                var Result = db.SaveChanges();
                if (Result == 1)
                {
                    return RedirectToAction("Index", "User");
                }

            }
            else
            {
                ModelState.AddModelError("", "Chưa nhập đầy đủ thông tin");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            db = new WebShopDbContext();
            AccountUser item = new AccountUser();

            var NameUser = Session["NameUser"] as ShopBanHang.Models.tblAccount;

            var item1 = db.tblAccounts.Find(id);
            var item2 = db.tblUsers.Where(x => x.Account_ID == id).FirstOrDefault();

            item.Account.AccountName = item1.AccountName;
            item.Account.Password = item1.Password;
            item.User.UserName = item2.UserName;
            item.User.Sex = item2.Sex;
            item.User.Birthday = item2.Birthday;
            item.User.Address = item2.Address;
            item.User.Email = item2.Email;
            item.User.ID = item2.ID;
            item.User.Phone = item2.Phone;
            item.User.ImageUrl = item2.ImageUrl;
            item.User.Description = item2.Description;

            item.Account.Status = item.User.Status = item2.Status;
            item.Account.CreatedDate = item.User.CreatedDate = DateTime.Now;
            item.Account.CreatedUser = item.User.CreatedUser = NameUser.AccountName;
            item.Account.DateIssued = item1.DateIssued;
            item.Account.ModifiedDate = item.User.ModifiedDate = DateTime.Now;
            item.Account.ModifiedUser = item.User.ModifiedUser = NameUser.AccountName;
            return View(item);
        }

        public ActionResult Delete(tblAccount model, int id)
        {
            try
            {
                db = new WebShopDbContext();
                //var ID = Convert.ToInt32(id);
                var item = db.tblAccounts.Where(x => x.ID == id).FirstOrDefault(); ;
                if (item != null)
                {
                    db.tblAccounts.Remove(item);
                    db.SaveChanges();
                }
                var item2 = db.tblUsers.Where(x => x.Account_ID == id).FirstOrDefault();
                if (item2 != null)
                {
                    db.tblUsers.Remove(item2);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }

}