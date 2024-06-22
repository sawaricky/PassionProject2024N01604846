﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject2024N01604846.Models
{
    public class InstrumentLesson
    {
        /// <summary>
        /// Represents an instrument lesson entity in the system, including properties such as lesson name, start date, end date, associated instructor, and collection of associated academies.
        /// </summary>
        [Key]
        public int LessonID {  get; set; }
        //guitar/piano etc
        public string LessonName { get; set; }
        //practical/theory
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}


        //an instructor has one class at one time
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        //an instructor can have many instrumemnt lessons



    }
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for an instrument lesson entity in the system, including properties such as lesson ID, lesson name, start date, end date, instructor ID, first name, and last name.
    /// </summary>
    public class InstrumentLessonDto
    {
        public int LessonID { get; set; }
        public string LessonName { get; set;}
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}

        public int InstructorId { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}