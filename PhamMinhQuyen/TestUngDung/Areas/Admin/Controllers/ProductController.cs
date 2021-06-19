using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEF.DAO;
using System.Web.Mvc;
using PagedList;
using ModelEF.Model;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        ProductDao db = new ProductDao();
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pagesize = 4)
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 4)
        {
            var product = new ProductDao();
            var model = product.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }



        [HttpGet]
        public ActionResult Create()
        {          
            var dao = new CategoryDao();
            ViewBag.ListSP = new SelectList(dao.ListAll(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
               
                string result = db.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Tạo mới sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    SetAlert("Tạo mới sản phẩm không thành công", "error");
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var dao = new CategoryDao();
            ViewBag.DSSanPham = new SelectList(dao.ListAll(), "ID", "Name");
            return View(db.Find(id));

        }
        [HttpPost]
        public ActionResult Details(Product model)
        {
            db.productDetails(model);
            return RedirectToAction("Index", "Product");
        }
    }
}