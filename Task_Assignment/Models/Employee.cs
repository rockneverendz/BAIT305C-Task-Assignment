using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_Assignment.Models
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; }
        public Position Position { get; set; }
        public Team Team { get; set; }
        public Status Status { get; set; }
        public string Security { get; set; }
    }

    public enum Position
    {
        Director,
        HumanResource,
        Finance,
        Admin,
        Manager,
        QualityAssuranceEngineer,
        SolutionArchitect,
        BusinessAnalysis,
        ArtDirector,
        TeamLead,
        SeniorSoftwareEngineer,
        UIEngineer,
        SupportEngineer,
        InfrastructureSupportEngineer,
    }

    public enum Team
    {
        Operation,
        ProjectManagement,
        Architect,
        Designer,
        Development,
        InfrastructureSupport,
        ProductionSupport,
        QualityAssurance,
    }

    public enum Status
    {
        Active,
        Disabled,
        Suspended,
    }
}