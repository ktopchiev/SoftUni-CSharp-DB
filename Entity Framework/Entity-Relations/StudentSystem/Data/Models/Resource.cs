using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(4000)")]
        public string Url { get; set; }

        public ResourceType ResosurceType { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
