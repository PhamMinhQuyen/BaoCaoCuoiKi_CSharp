using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;
using ModelEF.DAO;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public string PassWord { get; private set; }
        public string UserName { get; private set; }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserAccountDao();
                var result = dao.Login(user.UserName, Encryptor.EncryptMD5(user.PassWord),
                    user.status);
                if (result == 1 )
                {
                    // ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSON, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}