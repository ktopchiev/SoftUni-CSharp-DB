using Microsoft.Data.SqlClient;
using System;
using _02_VillainNames;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _02_Villain_Names
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SqlConnection conn = new SqlConnection(Configuration.CONNECTION_STRING);
            conn.Open();

            await using (conn)
            {
                SqlCommand sqlCommand = new SqlCommand(Queries.GET_VILLAIN_NAMES, conn);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                await using (reader)
                {
                    while (reader.Read())
                    {
                        string villainName = (string)reader["Name"];
                        int minionsNumber = (int)reader["MinionsCount"];
                        Console.WriteLine($"{villainName} - {minionsNumber}");
                    }

                    sw.Stop();
                    Console.WriteLine(sw.Elapsed);
                }
            }
        }
    }
}

