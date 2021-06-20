using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ModelEF.DAO;
using ModelEF.Models;

namespace TestUngDung.Areas.admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: admin/SanPham
        public ActionResult Index(string idDM, int page = 1, int pageSize = 5)
        {
            SanPhamDAO spDAO = new SanPhamDAO();
            var listSP = spDAO.GetAllSanPham(idDM, page, pageSize);
            ViewBag.listDM = spDAO.GetAllDanhMuc();
            TempData["idDM"] = idDM;
            return View(listSP);
        }

        public ActionResult Create()
        {
            SanPhamDAO spDAO = new SanPhamDAO();
            ViewBag.listDM = spDAO.GetAllDanhMuc();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblSanPham sp)
        {
            SanPhamDAO spDAO = new SanPhamDAO();
            try
            {
                ViewBag.listDM = spDAO.GetAllDanhMuc();

                if (ModelState.IsValid)
                {
                    spDAO.InsertSanPham(sp);
                    SetAlert("Thêm sản phẩm thành công!", 0);
                    return RedirectToAction("Index");
                }
                return View(sp);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult XemChiTiet(string id)
        {
           
            SanPhamDAO spDAO = new SanPhamDAO();
            tblSanPham sp = spDAO.GetSanPham(id);
            ViewBag.listDM = spDAO.GetAllDanhMuc();
            return View(sp);
        }

        public ActionResult XemDanhMuc(string id)
        {

            SanPhamDAO spDAO = new SanPhamDAO();
            tblDanhMuc dm = spDAO.GetDanhMuc(id);
            ViewBag.listDM = spDAO.GetAllDanhMuc();
            return View(dm);
        }
    }
}