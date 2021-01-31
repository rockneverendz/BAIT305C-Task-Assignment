using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_Assignment.Data;
using Task_Assignment.Infrastructure;
using Task_Assignment.Models;
using Task_Assignment.ViewModels;

namespace Task_Assignment.Controllers
{
    public class EmployeesController : Controller
    {
        private const int PageSize = 3;
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult IsUserNameUnique(string Username)
        {
            bool isUnique = !db.Employees.Any(e => e.Username.Equals(Username) );
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
        [EmployeeAuthorize]
        public ActionResult Index(string sortOrder, int? page)
        {
            var employees = from e in db.Employees 
                            select e;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.UsernameSortParm = String.IsNullOrEmpty(sortOrder) ? "Username_Desc" : "";
            ViewBag.FullNameSortParm = sortOrder == ("FullName") ? "FullName_Desc" : "FullName";
            ViewBag.JoinDateSortParm = sortOrder == ("JoinDate") ? "JoinDate_Desc" : "JoinDate";
            ViewBag.TeamSortParm = sortOrder == ("Team") ? "Team_Desc" : "Team";
            ViewBag.PositionSortParm = sortOrder == ("Position") ? "Position_Desc" : "Position";
            ViewBag.StatusSortParm = sortOrder == ("Status") ? "Status_Desc" : "Status";

            switch (sortOrder)
            {
                case "Username_Desc":
                    employees = employees.OrderByDescending(e => e.Username);
                    break;
                case "FullName":
                    employees = employees.OrderBy(e => e.FullName);
                    break;
                case "FullName_Desc":
                    employees = employees.OrderByDescending(e => e.FullName);
                    break;
                case "JoinDate":
                    employees = employees.OrderBy(e => e.JoinDate);
                    break;
                case "JoinDate_Desc":
                    employees = employees.OrderByDescending(e => e.JoinDate);
                    break;
                case "Team":
                    employees = employees.OrderBy(e => e.Team);
                    break;
                case "Team_Desc":
                    employees = employees.OrderByDescending(e => e.Team);
                    break;
                case "Position":
                    employees = employees.OrderBy(e => e.Position);
                    break;
                case "Position_Desc":
                    employees = employees.OrderByDescending(e => e.Position);
                    break;
                case "Status":
                    employees = employees.OrderBy(e => e.Status);
                    break;
                case "Status_Desc":
                    employees = employees.OrderByDescending(e => e.Status);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Username);
                    break;
            }

            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, PageSize));
        }

        // GET: Employees/Create
        [EmployeeAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [EmployeeAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Username,Email,FullName,Password,ComfirmPassword,JoinDate,Position,Team,Security")] CreateEmployee createEmployee)
        {
            if (ModelState.IsValid)
            {
                var employee = createEmployee.ToEmployee();

                employee.Status = Status.Active;

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createEmployee);
        }

        // GET: Employees/Edit/5
        [EmployeeAuthorize]
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
        [EmployeeAuthorize]
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
        [EmployeeAuthorize]
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
