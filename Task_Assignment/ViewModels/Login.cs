using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_Assignment.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Please fill-in username.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill-in password.")]
        public string Password { get; set; }
    }
}