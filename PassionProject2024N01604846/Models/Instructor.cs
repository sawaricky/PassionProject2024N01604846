﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PassionProject2024N01604846.Models
{
    /// <summary>
    /// Represents an instructor entity in the system, including properties such as first name, last name, instructor number, hire date, and wages.
    /// </summary>
    public class Instructor
    {
        // primary key
        [Key]
        public int InstructorId { get; set; }
    
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string InstructorNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Wages { get; set; }
    }
    /// <summary>
    /// Represents a DTO (Data Transfer Object) for an instructor entity in the system.
    /// Includes properties such as first name, last name, instructor number, hire date, and wages.
    /// </summary>
    public class InstructorDto
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        public string InstructorNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Wages { get; set; }
    }

    }