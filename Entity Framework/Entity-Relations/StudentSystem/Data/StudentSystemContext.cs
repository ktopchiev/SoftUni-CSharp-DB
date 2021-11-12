using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public StudentSystemContext()
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KT;Database=StudentSystem;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(student =>
            {
                student.HasKey(x => x.StudentId);

                student.Property(x => x.StudentId)
                    .ValueGeneratedOnAdd();

                student.Property(x => x.Name)
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsUnicode()
                    .IsRequired();

                student.Property(x => x.PhoneNumber)
                    .HasColumnType("char(10)")
                    .HasMaxLength(10);

                student.Property(x => x.RegisteredOn)
                    .HasColumnType("datetime2")
                    .IsRequired();

                student.Property(s => s.Birthday)
                    .HasColumnType("datetime2")
                    .IsRequired(false);

                student.HasCheckConstraint("CHK_PhoneNumber", "LEN(PhoneNumber) = 10");
            });

            modelBuilder.Entity<Course>(course =>
            {
                course.HasKey(x => x.CourseId);

                course.Property(c => c.CourseId)
                    .ValueGeneratedOnAdd();

                course.Property(c => c.Name)
                    .HasColumnType("nvarchar(80)")
                    .HasMaxLength(80)
                    .IsUnicode()
                    .IsRequired();

                course.Property(c => c.Description)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(4000)
                    .IsUnicode();

                course.Property(c => c.StartDate)
                    .HasColumnType("datetime2")
                    .IsRequired();

                course.Property(c => c.EndDate)
                    .HasColumnType("datetime2")
                    .IsRequired();

                course.Property(c => c.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

            });

            modelBuilder.Entity<Resource>(resource =>
            {
                resource.HasKey(r => r.ResourceId);

                resource.Property(r => r.ResourceId)
                    .ValueGeneratedOnAdd();

                resource.Property(r => r.Name)
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50)
                    .IsUnicode()
                    .IsRequired();

                resource.Property(r => r.Url)
                    .HasColumnType("varchar(max)")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .IsRequired();

                resource.Property(r => r.ResourceType)
                    .HasConversion<string>()
                    .IsRequired();

                resource.HasCheckConstraint("CHK_ResourceTypeEnum", "ResourceType IN ('Video', 'Presentation', 'Document', 'Other')");

                resource.Property(r => r.CourseId)
                    .HasColumnType("int")
                    .IsRequired();

                resource
                    .HasOne(r => r.Course)
                    .WithMany(r => r.Resources)
                    .HasForeignKey(r => r.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Homework>(homework =>
            {
                homework.HasKey(h => h.HomeworkId);

                homework.Property(h => h.HomeworkId)
                    .ValueGeneratedOnAdd();

                homework.Property(h => h.Content)
                    .HasColumnType("varchar(max)")
                    .HasMaxLength(4000)
                    .IsRequired()
                    .IsUnicode(false);

                homework.Property(h => h.ContentType)
                    .HasConversion<string>()
                    .IsRequired();

                homework.HasCheckConstraint("CHK_Homework_ContentTypeEnum", "ContentType IN ('Application', 'Pdf', 'Zip')");

                homework.Property(h => h.SubmissionTime)
                    .HasColumnType("datetime2")
                    .IsRequired();

                homework.Property(h => h.StudentId)
                    .HasColumnType("int")
                    .IsRequired(true);

                homework.Property(h => h.CourseId)
                    .HasColumnType("int")
                    .IsRequired(true);

                homework
                    .HasOne(h => h.Course)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(homework => homework.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);

                homework
                    .HasOne(h => h.Student)
                    .WithMany(h => h.HomeworkSubmissions)
                    .HasForeignKey(h => h.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(sc => new { sc.StudentId, sc.CourseId });

                sc
                    .HasOne(s => s.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(s => s.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                sc
                    .HasOne(s => s.Course)
                    .WithMany(s => s.StudentsEnrolled)
                    .HasForeignKey(s => s.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
