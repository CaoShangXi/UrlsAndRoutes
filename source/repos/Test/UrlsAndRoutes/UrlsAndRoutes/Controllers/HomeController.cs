using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">MVC框架会尝试将URL的值转换成所定义的任何参数类型，前提是参数名必须与路由片段变量名相同，不区分大小写</param>
        /// <returns></returns>
        public ActionResult CustomVariable(string id="DefaultId")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id;
            ViewBag.Catchall = RouteData.Values["catchall"];
            return View("ActionName");
        }
    }
}