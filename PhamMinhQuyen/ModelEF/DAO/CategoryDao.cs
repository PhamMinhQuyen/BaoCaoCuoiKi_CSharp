using System;
using System.Collections.Generic;
using System.Linq;
using ModelEF.Model;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private PhamMinhQuyenContext db;
        public CategoryDao()
        {
            db = new PhamMinhQuyenContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
    }
}
