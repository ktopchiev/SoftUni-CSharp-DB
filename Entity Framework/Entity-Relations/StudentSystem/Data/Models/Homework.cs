using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar(4000)")]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
