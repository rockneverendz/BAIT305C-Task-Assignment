using System;
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
    public class EditEmployee
    {
        public string Username { get; set; }

        [DisplayName("Employee ID")]
        public long EmployeeID { get; set; }

        [Required(ErrorMessage = "Please fill-in valid email address.")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "This email address is not valid.")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Full name must not exceed 20 characters.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{8,15}$", ErrorMessage = "Password must be 8-15 characters, and include letters and numbers.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
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

        public Status Status { get; set; }

        [Required(ErrorMessage = "Please fill-in security.")]
        [StringLength(40, ErrorMessage = "Security must not exceed 40 characters.")]
        public string Security { get; set; }

        public void Fill(Employee employee)
        {
            Username = employee.Username;
            EmployeeID = employee.EmployeeID;
            Email = employee.Email;
            FullName = employee.FullName;
            JoinDate = employee.JoinDate;
            Position = employee.Position;
            Team = employee.Team;
            Status = employee.Status;
            Security = employee.Security;
        }

        public void UpdateOriginal(Employee original)
        {
            original.Email = Email; 
            original.FullName = FullName;
            if (!String.IsNullOrEmpty(Password)) original.Password = Password;
            original.JoinDate = JoinDate;
            original.Position = Position;
            original.Team = Team;
            original.Status = Status;
            original.Security = Security;
        }
    }
}