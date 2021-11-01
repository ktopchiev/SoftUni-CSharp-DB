using System;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database first model - dotnet ef dbcontext scaffold "Server=KTOPCHIEV-LAPTO\SQLEXPRESS; Database=SoftUni; Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -o Models

            var db = new SoftUniContext();
            var employees = db.Employees.Where(e => e.FirstName == "Guy")
                .GroupBy(x => x.Address.AddressText)
                .Select(x => new { Name = x.Key})
                .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Name}");
            }

            //db.Towns.Add(new Town { Name = "Dimitrovgrad" });
            //db.SaveChanges();
        }
    }
}
