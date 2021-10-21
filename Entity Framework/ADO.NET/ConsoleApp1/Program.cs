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
                SqlCommand command = new SqlCommand("SELECT TOP 5 * FROM Employees", connection);
                SqlDataReader reader = command.ExecuteReader();
                
                using (reader)
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        Console.WriteLine(firstName);
                    }
                }
            }

        }
    }
}
