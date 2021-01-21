using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task_Assignment.Models;

namespace Task_Assignment.Data
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            IList<Employee> list = new List<Employee>
            {
                new Employee
                {
                    Username = "employee1",
                    EmployeeID = 1001,
                    FullName = "Employee One",
                    Email = "employee1@asp.net",
                    Password = "1111aaaa",
                    JoinDate = DateTime.Today.AddDays(-10),
                    Position = Position.SupportEngineer,
                    Team = Team.ProjectManagement,
                    Security = "securityone",
                },

                new Employee
                {
                    Username = "employee2",
                    EmployeeID = 2002,
                    FullName = "Employee Two",
                    Email = "employee2@asp.net",
                    Password = "2222bbbb",
                    JoinDate = DateTime.Today.AddDays(-50),
                    Position = Position.UIEngineer,
                    Team = Team.Development,
                    Security = "securitytwo",
                },

                new Employee
                {
                    Username = "employee3",
                    EmployeeID = 3003,
                    FullName = "Employee Three",
                    Email = "employee3@asp.net",
                    Password = "3333cccc",
                    JoinDate = DateTime.Today.AddDays(-100),
                    Position = Position.TeamLead,
                    Team = Team.ProductionSupport,
                    Security = "securitythree",
                },

                new Employee
                {
                    Username = "employee4",
                    EmployeeID = 4004,
                    FullName = "Employee Four",
                    Email = "employee4@asp.net",
                    Password = "4444dddd",
                    JoinDate = DateTime.Today.AddDays(-200),
                    Position = Position.Manager,
                    Team = Team.Designer,
                    Security = "securityfour",
                },

                new Employee
                {
                    Username = "employee5",
                    EmployeeID = 5005,
                    FullName = "Employee Five",
                    Email = "employee5@asp.net",
                    Password = "5555eeee",
                    JoinDate = DateTime.Today.AddDays(-300),
                    Position = Position.Director,
                    Team = Team.Operation,
                    Security = "securityfive",
                }
            };

            context.Employees.AddRange(list);

            base.Seed(context);
        }
    }
}