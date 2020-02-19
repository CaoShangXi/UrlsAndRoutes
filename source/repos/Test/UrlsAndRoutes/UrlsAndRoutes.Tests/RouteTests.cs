using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Reflection;
using System.Web;
using System.Web.Routing;

namespace UrlsAndRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            //创建模仿请求
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)//为对象建立行为
                .Returns(targetUrl);//为行为返回值
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);
            //创建模仿响应
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns<string>(s => s);
            //创建使用上述请求和响应的模仿上下文
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);
            return mockContext.Object;
        }
        
        public void TestRouteMatch(string url,String controller,string action,object routeProperties=null,string httpMethod="GET")
        {
            //准备
            RouteCollection routes=new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            //动作-处理路由
            RouteData result=routes.GetRouteData(CreateHttpContext(url,httpMethod));
            //断言
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result,controller,action,routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
        {
            //声明一个委托
            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            };
            bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);
            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name)) && valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null)))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRouteFail(string Url)
        {
            //准备
            RouteCollection routes=new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            //动作-处理路由
            RouteData result=routes.GetRouteData(CreateHttpContext(Url));
            //断言
            Assert.IsTrue(result==null||result.Route==null);
        }

        [TestMethod]
        public void TestIncomingRoutes()
        {
            ////对我们希望接收的URL进行检查
            //TestRouteMatch("~/","Home","Index");
            ////检查通过片段获取的值
            //TestRouteMatch("~/Customer", "Customer", "Index");
            //TestRouteMatch("~/Customer/List", "Customer", "List");
            ////确保太多或太少的片段不会匹配
            //TestRouteFail("~/Customer/List/All");
            //TestRouteMatch("~/Shop/Index","Home","Index");
            //测试自定义片段变量
            //TestRouteMatch("~/","Home","Index",new { id="DefaultId"});//在单元测试中必须把默认URL指定为“~/”，这是ASP.NET将URL表示给路由系统的方式，如果用“”或“/”定义路由则会引发异常
            //TestRouteMatch("~/Customer", "Customer", "Index", new { id = "DefaultId" });
            //TestRouteMatch("~/Customer/List", "Customer", "List", new { id = "DefaultId" });
            //TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
            //TestRouteMatch("~/Customer/List/All/Delete","Customer","List",new {id="All",catchall="Delete" });
            //TestRouteMatch("~/Customer/List/All/Delete/Perm", "Customer", "List", new { id = "All", catchall = "Delete/Perm" });
            //测试路由约束
            TestRouteMatch("~/","Home","Index");
            TestRouteMatch("~/Home", "Home", "Index");
            TestRouteMatch("~/Home/Index", "Home", "Index");
            TestRouteMatch("~/Home/About", "Home", "About");
            TestRouteMatch("~/Home/About/MyId", "Home", "About",new {id="MyId" });
            TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About",new { id="MyId",catchall="More/Segments"});

            TestRouteFail("~/Home/OtherAction");
            TestRouteFail("~/Acount/Index");
            TestRouteFail("~/Acount/About");
        }
    }
}
