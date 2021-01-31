using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Task_Assignment.Data;

namespace Task_Assignment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new ApplicationDbInitializer());
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => new MyIdProvider());
        }
    }

    internal class MyIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            return request.Cookies["EmployeeID"].Value;
        }
    }
}
