using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            //Console.WriteLine(AddNewAddressToEmployee(context));
            //Console.WriteLine(GetEmployeesInPeriod(context));
            //Console.WriteLine(GetAddressesByTown(context));
            //Console.WriteLine(GetEmployee147(context));
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
            Console.WriteLine(GetLatestProjects(context));
        }

        //Problem 03
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

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Department = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department} - ${e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            Address address = new Address();
            address.AddressText = "Vitoshka 15";

            employee.Address = address;
            employee.Address.TownId = 4;
            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new
                {
                    e.Address.AddressId,
                    e.Address.AddressText
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine(e.AddressText);
            }

            return sb.ToString().Trim();
        }

        //Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(e => e.Project)
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Projects = e.EmployeesProjects.Select(ep => new 
                    {
                        Name = ep.Project.Name,
                        StartDate = ep.Project.StartDate,
                        EndDate = ep.Project.EndDate
                    }),
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName
                })
                .Take(10)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var em in employees)
            {
                sb.AppendLine($"{em.FirstName} {em.LastName} - Manager: {em.ManagerFirstName} {em.ManagerLastName}");

                foreach (var project in em.Projects)
                {
                    var endDate = project.EndDate == null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    var startDate = project.StartDate.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(e => e.Employees)
                .Select(e => new
                {
                    TownName = e.Town.Name,
                    Address = e.AddressText,
                    EmployeesNum = e.Employees.Select(e => e.EmployeeId).Count()
                })
                .OrderByDescending(e => e.EmployeesNum)
                .ThenBy(e => e.TownName)
                .ThenBy(e => e.Address)
                .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in addresses)
            {
                var count = employee.EmployeesNum;
                sb.AppendLine($"{employee.Address}, {employee.TownName} - {count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(e => e.Project)
                        .OrderBy(p => p.Name)
                        .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee[0].FirstName} {employee[0].LastName} - {employee[0].JobTitle}");

            foreach (var project in employee[0].Projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            //var employees = context.Departments
            //    .Include(e => e.Employees)
            //    .Select(e => new
            //    {
            //        DepartmentName = e.Name,
            //        ManagerName = e.Manager.FirstName,
            //        ManagerLastName = e.Manager.LastName,
            //        Employees = e.Employees.Select(e => new
            //        {
            //            FirstName = e.FirstName,
            //            LastName = e.LastName,
            //            JobTitle = e.JobTitle
            //        })
            //        .OrderBy(e => e.FirstName)
            //        .ThenBy(e => e.LastName)
            //        .ToList(),
            //        EmployeesCount = e.Employees.Select(e => e.EmployeeId).Count()
            //    })
            //    .Where(d => d.EmployeesCount > 5)
            //    .OrderBy(d => d.DepartmentName)
            //    .ToList()
            //    .OrderBy(d => d.EmployeesCount);

            //StringBuilder sb = new StringBuilder();

            //foreach (var emp in employees)
            //{
            //    sb.AppendLine($"{emp.DepartmentName} - {emp.ManagerName} {emp.ManagerLastName}");
            //    foreach (var employee in emp.Employees)
            //    {
            //        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            //    }
            //}

            //return sb.ToString().TrimEnd();

            StringBuilder content = new StringBuilder();

            var departments = context
                .Departments.Where(department => department.Employees.Count > 5)
                .Include(x => x.Manager)
                .Include(x => x.Employees)
                .OrderBy(department => department.Employees.Count)
                .ThenBy(x => x.Name)
                .ToArray();

            foreach (var department in departments)
            {
                content.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                var employees = department.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

                foreach (var employee in employees)
                {
                    content.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return content.ToString().TrimEnd();
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate,
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
