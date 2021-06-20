using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.admin.Models;
using ModelEF.DAO;
using TestUngDung.Common;

namespace TestUngDung.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel acc)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hãy nhập tài khoản và mật khẩu!");
                return View();
            }

            var dao = new UserDAO();
            var rs = dao.Login(acc.Username, Encryptor.EncryptorMD5(acc.Password));

            if (rs == 1)
            {
                Session.Add(Constants.USER_SESSION, acc);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác!");
            }
            return View();
        }
    }
}