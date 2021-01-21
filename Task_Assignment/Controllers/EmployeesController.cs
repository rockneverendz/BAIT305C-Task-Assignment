using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_Assignment.Data;
using Task_Assignment.Models;
using Task_Assignment.ViewModels;

namespace Task_Assignment.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult IsUserNameUnique(string Username)
        {
            bool isUnique = !db.Employees.Any(e => e.Username == Username);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult IsEmployeeIDUnique(long EmployeeID)
        {
            bool isUnique = !db.Employees.Any(e => e.EmployeeID == EmployeeID);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Username,Email,FullName,Password,ComfirmPassword,JoinDate,Position,Team,Security")] CreateEmployee createEmployee)
        {
            if (ModelState.IsValid)
            {
                var employee = createEmployee.ToEmployee();

                employee.Status = Status.Active;
                employee.IPAddress = Request.UserHostAddress;

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createEmployee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EditEmployee modal = new EditEmployee();
            modal.Fill(employee);
            return View(modal);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Email,FullName,Password,ComfirmPassword,JoinDate,Position,Team,Status,Security")] EditEmployee modifiedEmployee)
        {
            if (ModelState.IsValid)
            {
                Employee originalEmployee = db.Employees.Find(modifiedEmployee.EmployeeID);
                modifiedEmployee.UpdateOriginal(originalEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modifiedEmployee);
        }

        // POST: Employees/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "EmployeeID")] DeleteEmployee modal)
        {
            Employee employee = db.Employees.Find(modal.EmployeeID);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
