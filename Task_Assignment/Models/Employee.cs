using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_Assignment.Models
{
    public class Employee
    {
        [Required]
        [Remote(action: "IsUserNameUnique", controller: "Employee", ErrorMessage = "This username has already been registered. Please enter a different username.")]
        public string Username { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Please fill-in employee ID.")]
        [Range(0, 9999999999, ErrorMessage = "Employee ID must be 1-10 numbers.")]
        [Remote(action: "IsEmployeeIDUnique", controller: "Employee", ErrorMessage = "This employee ID has already been registered. Please enter a different employee ID.")]
        public long EmployeeID { get; set; }

        [Required(ErrorMessage = "Please fill-in valid email address.")]
        [EmailAddress(ErrorMessage = "This email address is not valid.")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Full name must not exceed 20 characters.")]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please fill-in join date.")]
        public DateTime JoinDate { get; set; }
        
        [Required(ErrorMessage = "Please select a position.")]
        public Position Position { get; set; }
        
        [Required(ErrorMessage = "Please select a team.")]
        public Team Team { get; set; }
        
        public Status Status { get; set; }

        [Required(ErrorMessage = "Please fill-in security.")]
        [StringLength(40, ErrorMessage = "Security must not exceed 40 characters.")]
        public string Security { get; set; }

        public string IPAddress { get; set; }
    }

    public enum Position
    {
        [Description("Director")]
        Director,
        [Description("Human Resource")]
        HumanResource,
        [Description("Finance")]
        Finance,
        [Description("Admin")]
        Admin,
        [Description("Manager")]
        Manager,
        [Description("Quality Assurance Engineer")]
        QualityAssuranceEngineer,
        [Description("Solution Architect")]
        SolutionArchitect,
        [Description("Business Analysis")]
        BusinessAnalysis,
        [Description("Art Director")]
        ArtDirector,
        [Description("Team Lead")]
        TeamLead,
        [Description("Senior Software Engineer")]
        SeniorSoftwareEngineer,
        [Description("UI Engineer")]
        UIEngineer,
        [Description("Support Engineer")]
        SupportEngineer,
        [Description("Infrastructure Support Engineer")]
        InfrastructureSupportEngineer,
    }

    public enum Team
    {
        [Description("Operation")]
        Operation,
        [Description("Project Management")]
        ProjectManagement,
        [Description("Architect")]
        Architect,
        [Description("Designer")]
        Designer,
        [Description("Development")]
        Development,
        [Description("Infrastructure Support")]
        InfrastructureSupport,
        [Description("Production Support")]
        ProductionSupport,
        [Description("Quality Assurance")]
        QualityAssurance,
    }

    public enum Status
    {
        Active,
        Disabled,
        Suspended,
    }
}