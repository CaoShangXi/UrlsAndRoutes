using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //使用属性路由,例子参考CustomerController
            routes.MapMvcAttributeRoutes();
            routes.MapRoute("NewRoute","App/Do{action}",new { controller="Home"});
            routes.MapRoute("MyRoute","{controller}/{action}/{id}",new { controller="Home",action="Index",id=UrlParameter.Optional});

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //注册一条路由,对请求路径进行匹配
            //Route myRoute=new Route("{controller}/{action}",new MvcRouteHandler());
            //routes.Add("MyRoute",myRoute);

            //使用自定义路由约束
            //         routes.MapRoute("ChromeRoute", "{*catchall}",
            //             new
            //             {
            //                 controller = "Home",//默认值是在约束检查之前被运行
            //                 action = "Index",
            //             },
            //             new
            //             {
            //                 customConstraint = new UserAgentConstraint("Chrome")
            //             },//约束，匹配是Chrome浏览器的请求
            //new[] { "UrlsAndRoutes.AdditionalControllers" }); ;

            //使用类型和值约束
            //         routes.MapRoute("AddControllerRoute", "{controller}/{action}/{id}/{*catchall}",
            //             new{
            //             controller = "Home",//默认值是在约束检查之前被运行
            //             action = "Index",
            //             id = UrlParameter.Optional
            //         }, 
            //             new { controller = "^H.*",
            //                 action = "^Index$|^About$",
            //                 httpMethod = new HttpMethodConstraint("GET"),
            //                 id=new CompoundRouteConstraint(new IRouteConstraint[] { new AlphaRouteConstraint(),new MinLengthRouteConstraint(6)}) },//约束，匹配controller以H开头并且action是Index或About的片段
            //new[] { "UrlsAndRoutes.Controllers" });

            //使用正则表达式对路由进行约束
            //routes.MapRoute("AddControllerRoute", "{controller}/{action}/{id}/{*catchall}", new
            //{
            //    controller = "Home",//默认值是在约束检查之前被运行
            //    action = "Index",
            //    id = UrlParameter.Optional
            //}, new { controller = "^H.*", action = "^Index$|^About$",httpMethod=new HttpMethodConstraint("GET") },//约束，匹配controller以H开头并且action是Index或About的片段
            //   new[] { "UrlsAndRoutes.AdditionalControllers" });

            //routes.MapRoute("AddControllerRoute", "{controller}/{action}/{id}/{*catchall}", new
            //{
            //    controller = "Home",//默认值是在约束检查之前被运行
            //    action = "Index",
            //    id = UrlParameter.Optional
            //}, new { controller = "^H.*",action="^Index$|^About$"},//约束，匹配controller以H开头并且action是Index或About的片段
            //    new[] { "UrlsAndRoutes.AdditionalControllers" });

            //routes.MapRoute("AddControllerRoute", "{controller}/{action}/{id}/{*catchall}", new
            //{
            //    controller = "Home",//默认值是在约束检查之前被运行
            //    action = "Index",
            //    id = UrlParameter.Optional
            //}, new { controller = "^H.*" },//约束，匹配controller以H开头的片段
            //    new[] { "UrlsAndRoutes.AdditionalControllers" });

            //两个控制器名字相同时，应以命名空间区分
            //routes.MapRoute("AddControllerRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "UrlsAndRoutes.AdditionalControllers" });
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "UrlsAndRoutes.Controllers" });
            //对URL定义全匹配模式({*catchall})，URL会被分解成controller=xx,action=xx,id=xx,catchall=xx/xx/xx这种格式
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index",id=UrlParameter.Optional });//该方法第三个参数为匿名类型，作用为Url片段提供默认值;UrlParameter.Optional表示id参数是可选的，有输入则取输入的值，没有则为null
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "DefaultId"});
            //routes.MapRoute("ShopSchema2", "Shop/OldAction", new { controller = "Home", action = "Index" });
            //routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });
            //routes.MapRoute("", "X{controller}/{action}");
            //routes.MapRoute("", "Public/{controller}/{action}", new { controller = "Home", action = "Index" });
        }
    }
}
