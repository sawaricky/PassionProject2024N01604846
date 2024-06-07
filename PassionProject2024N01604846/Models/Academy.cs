using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PassionProject2024N01604846.Models
{
    /// <summary>
    /// Represents an academy entity in the system, including properties such as academy name, academy address, and a collection of instrument lessons associated with the academy.
    /// </summary>
    public class Academy
    {
        [Key]
        public int AcademyId { get; set; } 

        public string AcademyName { get; set; }

        public string AcademyAddress { get; set; }

        //an academy can have multiple instructors

        public ICollection<InstrumentLesson> InstrumentLessons { get; set; }
    }
}