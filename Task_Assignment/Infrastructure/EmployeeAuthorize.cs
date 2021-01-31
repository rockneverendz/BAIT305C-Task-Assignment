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
        public void OnAuthentication(AuthenticationContext context)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var employeeID = context.HttpContext.Session["EmployeeID"];

                if (employeeID == null)
                {
                    context.Result = new HttpUnauthorizedResult("Unauthorized access. Please login first.");
                }
                else if (db.Employees.Find(employeeID).IPAddress != context.HttpContext.Request.UserHostAddress)
                {
                    context.HttpContext.Session.Clear();
                    context.Result = new HttpUnauthorizedResult("Logged out due to multiple login detected.");
                }
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