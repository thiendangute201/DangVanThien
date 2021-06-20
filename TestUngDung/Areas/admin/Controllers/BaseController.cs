using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "admin" }));
            }
            base.OnActionExecuted(filterContext);
        }

        protected void SetAlert(string message, int type)
        {
            TempData["AlertMessage"] = message;
            if(type == 0)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 1)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}