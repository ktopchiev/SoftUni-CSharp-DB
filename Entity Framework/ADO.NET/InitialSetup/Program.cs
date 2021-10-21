using Microsoft.Data.SqlClient;
using System;

namespace InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var conn = SetConnection();
            conn.Open();

            using (conn)
            {
                CreateDb(conn);
                CreateTable(conn);
            }
        }

        public static SqlConnection SetConnection()
        {
            string connStr = "Server=KTOPCHIEV-LAPTO\\SQLEXPRESS; Database=master; Integrated Security=true";
            SqlConnection conn = new SqlConnection(connStr);
            return conn;
        }

        public static void CreateDb(SqlConnection conn)
        {
            string cmdText = "CREATE DATABASE MinionsDB";
            SqlCommand sqlCmd = new SqlCommand(cmdText, conn);

            var execution = sqlCmd.ExecuteNonQuery();
        }

        public static void CreateTable(SqlConnection conn)
        {
            string createTablesCmdText = "USE MinionsDB" +
                    "\n" +
                    "CREATE TABLE Minions" +
                    "\n(" +
                    "   \nId INT PRIMARY KEY IDENTITY NOT NULL," +
                    "   \nName VARCHAR(50) NOT NULL," +
                    "   \nAge VARCHAR(50) NOT NULL," +
                    "   \nCountryCode INT FOREIGN KEY REFERENCES Countries (Id)," +
                    "\n)";
            SqlCommand cmd = new SqlCommand(createTablesCmdText, conn);
            int execute = cmd.ExecuteNonQuery();
            Console.WriteLine(execute);
        }
    }
}
