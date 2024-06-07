using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject2024N01604846.Models
{
    public class InstrumentLesson
    {
        //
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

        //an instructor can be at many academies 
        public ICollection<Academy> Academys { get; set;}

    }
    // Data Transfer Object (DTO) allows us to package the information for each model
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