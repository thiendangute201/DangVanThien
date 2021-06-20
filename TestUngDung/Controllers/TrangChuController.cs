using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Models;
using PagedList;
namespace TestUngDung.Controllers
{
    public class TrangChuController : Controller
    {
        public ActionResult Index(string idDM, int page = 1, int pageSize = 5)
        {
            SanPhamDAO spDAO = new SanPhamDAO();
            var listSP = spDAO.GetAllSanPham(idDM, page, pageSize);
            ViewBag.listDM = spDAO.GetAllDanhMuc();
            TempData["idDM"] = idDM;
            return View(listSP);
        }
    }
}