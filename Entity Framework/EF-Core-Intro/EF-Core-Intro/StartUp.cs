using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFullInformation(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            
            var employees = context.Employees
                .Select(e => new 
                        {
                            e.EmployeeId,
                            e.FirstName,
                            e.LastName,
                            e.MiddleName,
                            e.JobTitle,
                            e.Salary
                        })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                if (e.MiddleName != null)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
                }
                else
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} {e.JobTitle} {e.Salary:f2}");
                }
            }

            return sb.ToString().Trim();
            
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {

        }
    }
}
