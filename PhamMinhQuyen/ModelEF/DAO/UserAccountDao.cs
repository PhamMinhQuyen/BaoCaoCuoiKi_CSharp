using System;
using System.Collections.Generic;
using System.Linq;
using ModelEF.Model;

using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelEF.DAO
{
    public class UserAccountDao
    {
        private PhamMinhQuyenContext db;
        public UserAccountDao()
        {
            db = new PhamMinhQuyenContext();
        }

        public int Login(string user, string pass,string status )
        {
            status = "Activated";
            var result = db.UserAccounts.SingleOrDefault(x => x.Username.Contains(user)
            && x.Password.Contains(pass) && x.Status.Contains(status));
            
            if (result == null )
                return 0;
            else
                return 1; 
        }

        

       
        public UserAccount Find(int ID)
        {

            return db.UserAccounts.Find(ID);
        }
        public bool Delete(int ID)
        {

            try
            {
                var account = db.UserAccounts.Find(ID);
                db.UserAccounts.Remove(account);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<UserAccount> ListAll()
        {

            return db.UserAccounts.ToList();
        }
        public IEnumerable<UserAccount> LisWheretAll(string search, int page, int pagesize)

        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(search))
            {

                model = model.Where(x => x.Username.Contains(search));
            }

            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
    }
}
