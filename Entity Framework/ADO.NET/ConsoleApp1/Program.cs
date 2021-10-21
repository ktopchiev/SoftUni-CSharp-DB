using Microsoft.Data.SqlClient;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Server=KTOPCHIEV-LAPTO\\SQLEXPRESS;DataBase=SoftUni;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connString);

            connection.Open();

            using (connection)
            {
                string cmdText = "SELECT TOP 5 * FROM Employees";
                SqlCommand command = new SqlCommand(cmdText, connection);
                SqlDataReader reader = command.ExecuteReader();
                
                using (reader)
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string) reader["LastName"];
                        decimal salary = (decimal) reader["Salary"];
                        Console.WriteLine($"{firstName} {lastName} - ${salary}");
                    }
                }
            }

        }
    }
}
