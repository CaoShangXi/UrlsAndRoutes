using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.AdditionalControllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id)
        {
            ViewBag.Controller = "Additional Controllers-Home";
            ViewBag.Action = "Index";
            ViewBag.CustomVariable = id;
            ViewBag.Catchall = RouteData.Values["catchall"];
            return View("ActionName");
        }
    }
}