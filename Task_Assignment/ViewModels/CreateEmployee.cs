﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Assignment.Models;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;


namespace Task_Assignment.ViewModels
{
    public class CreateEmployee
    {
        [Required(ErrorMessage = "Please fill-in username.")]
        [Remote(action: "IsUserNameUnique", controller: "Employees", ErrorMessage = "This username has already been registered. Please enter a different username.")]
        [RegularExpression(@"^(?!.*\s)(?=.*\d)(?=.*[a-zA-Z]).{8,15}$", ErrorMessage = "Username must be 8-15 characters, and include letters and numbers.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please fill-in employee ID.")]
        [Range(0, 9999999999, ErrorMessage = "Employee ID must be 1-10 numbers.")]
        [Remote(action: "IsEmployeeIDUnique", controller: "Employees", ErrorMessage = "This employee ID has already been registered. Please enter a different employee ID.")]
        [DisplayName("Employee ID")]
        public long EmployeeID { get; set; }

        [Required(ErrorMessage = "Please fill-in valid email address.")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "This email address is not valid.")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Full name must not exceed 20 characters.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill-in password.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{8,15}$", ErrorMessage = "Password must be 8-15 characters, and include letters and numbers.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill-in confirm password.")]
        [Compare("Password", ErrorMessage = "The password fields did not match.")]
        [DisplayName("Comfirm Password")]
        public string ComfirmPassword { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Please fill-in join date.")]
        [DisplayName("Join Date")]

        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Please select a position.")]
        public Position Position { get; set; }

        [Required(ErrorMessage = "Please select a team.")]
        public Team Team { get; set; }

        [Required(ErrorMessage = "Please fill-in security.")]
        [StringLength(40, ErrorMessage = "Security must not exceed 40 characters.")]
        public string Security { get; set; }

        public Employee ToEmployee()
        {
            return new Employee
            {
                Username = Username,
                EmployeeID = EmployeeID,
                FullName = FullName,
                Email = Email,
                Password = Password,
                JoinDate = JoinDate,
                Position = Position,
                Team = Team,
                Security = Security,
            };
        }

    }
}