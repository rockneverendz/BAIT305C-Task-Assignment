using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using Task_Assignment.Data;

namespace Task_Assignment.Infrastructure
{
    public class EmployeeAuthorize : ActionFilterAttribute, IAuthenticationFilter
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public void OnAuthentication(AuthenticationContext context)
        {
            var employeeID = context.HttpContext.Session["EmployeeID"];

            if (employeeID == null)
            {
                context.Result = new HttpUnauthorizedResult("Your session has timed out. Please login again.");
            }
            else if (db.Employees.Find(employeeID).IPAddress != context.HttpContext.Request.UserHostAddress)
            {
                context.Result = new HttpUnauthorizedResult("Logged out due to multiple login detected.");
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Index" },
                    }
                );
            }
            else if (context.Result is HttpUnauthorizedResult result)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Index" },
                        { "reason", result.StatusDescription},
                    }
                );
            }
        }
    }
}