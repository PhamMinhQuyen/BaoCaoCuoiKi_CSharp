using System;
using System.Collections.Generic;
using System.Linq;
using ModelEF.Model;

using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private PhamMinhQuyenContext db;
        public ProductDao()
        {
            db = new PhamMinhQuyenContext();
        }

        public List<Product> ListAll()
        {

            var product = from s in db.Products
                        orderby s.Quantity ascending, s.UnitCost descending
                        select s;
                        return product.ToList();
        }
        public IEnumerable<Product> LisWheretAll(string search, int page, int pagesize)

        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(search))
            {

                //model = model.Where(x => x.Name.Contains(search));
                return model.Where(x => x.Name.Contains(search)).
                    OrderBy(x => x.Name).ToPagedList(page, pagesize);
            }

            return model.OrderBy(x => x.Quantity).
                ThenByDescending(x => x.UnitCost).ToPagedList(page, pagesize);
        }

        public string Insert(Product entitySP)
        {
            db.Products.Add(entitySP);
            db.SaveChanges();
            return entitySP.ID.ToString();
        }

        public Product Find(int ID)
        {
            return db.Products.Find(ID);
        }
        public bool productDetails(Product entitySP)
        {
            try
            {
                var product = db.Products.Find(entitySP.ID);
                product.Name = entitySP.Name;
                product.UnitCost = entitySP.UnitCost;
                product.Quantity = entitySP.Quantity;
                product.Image = entitySP.Image;
                product.Description = entitySP.Description;
                product.Status = entitySP.Status;
                product.ID_Category = entitySP.ID_Category;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

      





        public List<Product> ListNewProduct(int status)
        {
            return db.Products.OrderBy(x => x.UnitCost).Take(status).ToList();
        }


        public List<Product> ListNewProduct1(int status)
        {
            return db.Products.OrderByDescending(x => x.UnitCost).Take(status).ToList();
        }
       



    }
}
