﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task_Assignment.Models
{
    public class RestrictedIP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string IPAddress { get; set; }
    }
}