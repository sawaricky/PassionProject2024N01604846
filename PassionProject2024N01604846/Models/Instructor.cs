using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PassionProject2024N01604846.Models
{

    public class Instructor
    {
        // primary kety
        [Key]
        public int InstructorId { get; set; }
        //Last name
        public string FirstName { get; set; }
        //Last name
        public string LastName { get; set; }
        public string InstructorNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Wages { get; set; }
    }
    public class InstructorDto
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        //Last name
        public string LastName { get; set; }
        public string InstructorNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Wages { get; set; }
    }

    }