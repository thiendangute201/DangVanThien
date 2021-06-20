using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Models;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDAO
    {
        DangVanThienContext db;
        public UserDAO()
        {
            db = new DangVanThienContext();
        }

        //Login
        public int Login(string uName, string uPass)
        {
            var rs = db.tblUserAccounts.FirstOrDefault(x => x.userName.Equals(uName) && x.password.Equals(uPass));
            return rs == null ? 0 : 1;
        }

        public IEnumerable<tblUserAccount> GetAllUserAccount(string searchStr, int page, int pageSize)
        {
            if(String.IsNullOrEmpty(searchStr))
                return db.tblUserAccounts.OrderBy(acc => acc.idUser).ToPagedList(page, pageSize);
            return db.tblUserAccounts.Where(acc => acc.idUser.Contains(searchStr) || acc.userName.Contains(searchStr)).
                OrderBy(acc => acc.idUser).ToPagedList(page, pageSize);
        }

        public bool Delete(string id)
        {
            var acc = db.tblUserAccounts.Find(id);

            if (acc.status.Equals("1"))
                return false;

            db.tblUserAccounts.Remove(acc);
            db.SaveChanges();
            return true;
        }
    }
}
