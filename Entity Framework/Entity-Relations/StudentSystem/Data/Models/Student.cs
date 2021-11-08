using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar(100)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime Birthday { get; set; }
    }
}
