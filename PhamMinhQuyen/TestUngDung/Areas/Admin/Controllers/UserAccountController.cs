using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using PagedList;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: Admin/UserAccount
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var account = new UserAccountDao();
            var model = account.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var account = new UserAccountDao();
            var model = account.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        public ActionResult Delete(int id)
        {
            new UserAccountDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}