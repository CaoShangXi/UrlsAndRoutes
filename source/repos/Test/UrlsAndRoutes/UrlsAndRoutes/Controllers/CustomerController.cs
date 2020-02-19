using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    [RoutePrefix("Users")]//使用RoutePrefix（路由前缀）
    public class CustomerController : Controller
    {
        [Route("~/Test")]//~/表示通过Test路径即可访问方法
        public ActionResult Index()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        [Route("Add/{user}/{id:int}")]
        public string Create(string user,int id)
        {
            return string.Format("User:{0},ID:{1}",user,id);
        }
        [Route("Add/{user}/{password:alpha:length(6)}")]//密码必须是6个字符
        public string ChangePass(string user,string password)
        {
            return string.Format("ChangePass Method - User:{0},Pass:{1}",user,password);
        }
        // GET: Customer
        public ActionResult List()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "List";
            return View("ActionName");
        }
    }
}