﻿using System;
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
        [StringLength(15)]
        public string Username { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Employee ID")]
        public long EmployeeID { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        [StringLength(20)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Join Date")]
        public DateTime JoinDate { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public Team Team { get; set; }

        public Status Status { get; set; }

        [Required]
        [StringLength(40)]
        public string Security { get; set; }

        public byte LoginAttempt { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string IPAddress { get; set; }
    }

    public enum Position : byte
    {
        [Display(Name = "Director")]
        Director,
        [Display(Name = "Human Resource")]
        HumanResource,
        [Display(Name = "Finance")]
        Finance,
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "Manager")]
        Manager,
        [Display(Name = "Quality Assurance Engineer")]
        QualityAssuranceEngineer,
        [Display(Name = "Solution Architect")]
        SolutionArchitect,
        [Display(Name = "Business Analysis")]
        BusinessAnalysis,
        [Display(Name = "Art Director")]
        ArtDirector,
        [Display(Name = "Team Lead")]
        TeamLead,
        [Display(Name = "Senior Software Engineer")]
        SeniorSoftwareEngineer,
        [Display(Name = "Software Engineer")]
        SoftwareEngineer,
        [Display(Name = "UI Engineer")]
        UIEngineer,
        [Display(Name = "Support Engineer")]
        SupportEngineer,
        [Display(Name = "Infrastructure Support Engineer")]
        InfrastructureSupportEngineer,
    }

    public enum Team : byte
    {
        [Display(Name = "Operation")]
        Operation,
        [Display(Name = "Project Management")]
        ProjectManagement,
        [Display(Name = "Architect")]
        Architect,
        [Display(Name = "Designer")]
        Designer,
        [Display(Name = "Development")]
        Development,
        [Display(Name = "Infrastructure Support")]
        InfrastructureSupport,
        [Display(Name = "Production Support")]
        ProductionSupport,
        [Display(Name = "Quality Assurance")]
        QualityAssurance,
    }

    public enum Status : byte
    {
        Active,
        Disabled,
        Suspended,
    }
}