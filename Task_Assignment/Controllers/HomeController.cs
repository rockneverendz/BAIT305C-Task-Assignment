﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Assignment.Data;
using Task_Assignment.ViewModels;

namespace Task_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                Session["LoginAttempt"] = Session["LoginAttempt"] == null ? (byte)1 : Convert.ToByte(Session["LoginAttempt"]) + 1;

                var user = db.Employees.Where(
                    e => e.Username.Equals(login.Username)
                ).FirstOrDefault();
                
                if (IsValid(user, login.Password))
                {
                    user.IPAddress = Request.UserHostAddress;
                    db.SaveChanges();

                    Session["LoginAttempt"] = null;
                    Session["EmployeeID"] = user.EmployeeID.ToString();
                    return RedirectToAction("Index", "Employees");
                }
            }
            return View("Index", login);
        }

        private bool IsValid(Models.Employee user, string password)
        {
            // TODO Check IP
            // if IP address in Ban list return false

            if (Convert.ToByte(Session["LoginAttempt"]) >= 10)
            {
                // TODO Ban IP
                ModelState.AddModelError("", "Unable to log in from disallowed IP address.");
                return false;
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Incorrect username / password. Please try again.");
                return false;
            }

            if (user.Status == Models.Status.Suspended)
            {
                ModelState.AddModelError("", "Too many failed login attempts. Account has been locked.  ");
                return false;
            }

            if (user.LoginAttempt >= 10)
            {
                user.Status = Models.Status.Suspended;
                user.LoginAttempt = 0;
                db.SaveChanges();
                ModelState.AddModelError("", "Too many failed login attempts. Account has been locked.  ");
                return false;
            }

            if (user.Password != password)
            {
                user.LoginAttempt++;
                db.SaveChanges();
                ModelState.AddModelError("", "Incorrect username / password. Please try again.");
                return false;
            }

            return true;
        }
    }
}