using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Models;
using PagedList;

namespace TestUngDung.Areas.admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: admin/Home
        public ActionResult Index(string searchStr, int page = 1, int pageSize = 5)
        {
            UserDAO userDAO = new UserDAO();
            SanPhamDAO spDAO = new SanPhamDAO();

            IEnumerable<tblUserAccount> listAcc = userDAO.GetAllUserAccount(searchStr, page, pageSize);
            ViewBag.listDM = spDAO.GetAllDanhMuc();

            if (!String.IsNullOrEmpty(searchStr))
                @ViewBag.searchStr = searchStr;
            return View(listAcc);
        }

        public ActionResult Delete(string id)
        {
            UserDAO userDAO = new UserDAO();
            if (userDAO.Delete(id))
            {
                SetAlert("Xóa thành công!", 0);
                return RedirectToAction("Index");
            }

            SetAlert("Xóa không thành công!", 2);
            return RedirectToAction("Index");
        }
    }
}