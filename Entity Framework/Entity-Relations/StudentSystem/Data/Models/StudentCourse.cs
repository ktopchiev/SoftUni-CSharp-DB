using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentSystem.Data.Models
{
    public class StudentCourse
    {
        [Key]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Key]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
    }
}
