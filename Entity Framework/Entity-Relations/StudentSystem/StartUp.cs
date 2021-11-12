using P01_StudentSystem.Data.Models;
using System;
using System.Linq;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();

            using (context)
            {
                Student student = new Student()
                {
                    Name = "Gosho",
                    PhoneNumber = "0888666888"
                };

                context.Students.Add(student);

                context.SaveChanges();

                var studentRec = context.Students.FirstOrDefault();
                Console.WriteLine($"{studentRec.Name} {studentRec.PhoneNumber}");
            }
        }
    }
}
