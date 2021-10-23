using Microsoft.Data.SqlClient;
using System;
using _02_VillainNames;
using System.Threading.Tasks;
using System.Data;

namespace _02_Villain_Names
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(Configuration.CONNECTION_STRING);
            conn.Open();

            await using (conn)
            {
                //await GetVillainsWithMoreThanThreeMinionsAsync(conn);
                //int id = int.Parse(Console.ReadLine());
                //await GetMinionsAndTheirAgeByVillainIdAsync(conn, id);

                //string[] minionInput = Console.ReadLine().Split(' ');
                //string[] villainInput = Console.ReadLine().Split(' ');
                //await AddMinionsAndVillainsAsync(conn, minionInput, villainInput);
            }
        }

        //Problem 02
        public static async Task GetVillainsWithMoreThanThreeMinionsAsync(SqlConnection conn)
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
            }
        }

        //Problem 03
        public static async Task GetMinionsAndTheirAgeByVillainIdAsync(SqlConnection conn, int id)
        {

            SqlCommand getVillainCmd = new SqlCommand(Queries.GET_VILLAIN_BY_ID, conn);
            getVillainCmd.Parameters.Add("@Id", SqlDbType.Int);
            getVillainCmd.Parameters["@Id"].Value = id;

            //Print villain name
            object villainReader = await getVillainCmd.ExecuteScalarAsync();

            if (villainReader != null)
            {

                Console.WriteLine($"Villain: {villainReader}");

                SqlCommand getMinionsCmd = new SqlCommand(Queries.GET_ALL_MINIONS_OF_A_VILLAIN_BY_ID, conn);
                getMinionsCmd.Parameters.Add("@Id", SqlDbType.Int);
                getMinionsCmd.Parameters["@Id"].Value = id;

                SqlDataReader minionsReader = await getMinionsCmd.ExecuteReaderAsync();

                using (minionsReader)
                {
                    if (minionsReader.HasRows)
                    {
                        while (await minionsReader.ReadAsync())
                        {
                            long row = minionsReader.GetInt64(0);
                            string minionName = minionsReader.GetString(1);
                            int minionAge = minionsReader.GetInt32(2);

                            Console.WriteLine($"{row}. {minionName} {minionAge}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("(no minions)");
                    }
                }
            }
            else
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
        }

        //Problem 04

        public static async Task AddMinionsAndVillainsAsync(SqlConnection conn, string[] minionInput, string[] villainInput)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;

            string minionName = minionInput[1];
            int minionAge = int.Parse(minionInput[2]);
            string townName = minionInput[3];

            string villainName = villainInput[1];

            sqlCommand = SetSqlCommandTextAndParameters(sqlCommand,Queries.GET_TOWN_ID_BY_NAME, "@townName", townName);

            object townId = await sqlCommand.ExecuteScalarAsync();

            if (townId == null)
            {
                //Add new town to db if it is not exist
                sqlCommand.CommandText = Queries.ADD_TOWN_TO_DB;
                await sqlCommand.ExecuteNonQueryAsync();
                Console.WriteLine($"Town {townName} was added to the database.");

                //Get new town id
                sqlCommand.CommandText = Queries.GET_TOWN_ID_BY_NAME;
                townId = await sqlCommand.ExecuteScalarAsync();
            }
            else
            {
                sqlCommand = SetSqlCommandTextAndParameters(sqlCommand, Queries.GET_VILLAIN_ID_BY_NAME, "@Name", villainName);
                
                object villainId = await sqlCommand.ExecuteScalarAsync();

                if (villainId == null)
                {
                    //Add new villain do the db if its not exist
                    sqlCommand.CommandText = Queries.ADD_VILLAIN_TO_DB;
                    await sqlCommand.ExecuteNonQueryAsync();
                    Console.WriteLine($"Villain {villainName} was added to the database.");

                    //Get new villain id
                    sqlCommand.CommandText = Queries.GET_VILLAIN_ID_BY_NAME;
                    villainId = await sqlCommand.ExecuteScalarAsync();
                }
                
                
                //Add new minion to db
                sqlCommand.CommandText = Queries.ADD_MINION_TO_DB;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar);
                sqlCommand.Parameters["@Name"].Value = minionName;
                sqlCommand.Parameters.Add("@Age", SqlDbType.Int);
                sqlCommand.Parameters["@Age"].Value = minionAge;
                sqlCommand.Parameters.Add("@TownId", SqlDbType.Int);
                sqlCommand.Parameters["@TownId"].Value = townId;

                await sqlCommand.ExecuteNonQueryAsync();

                //Add minion to vilain
                sqlCommand.CommandText = Queries.GET_MINION_ID_BY_NAME;

                object minionId = await sqlCommand.ExecuteScalarAsync();

                sqlCommand.CommandText = Queries.ADD_MINION_TO_VILLAIN;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("@MinionId", SqlDbType.Int);
                sqlCommand.Parameters["@MinionId"].Value = minionId;
                sqlCommand.Parameters.Add("@VillainId", SqlDbType.Int);
                sqlCommand.Parameters["@VillainId"].Value = villainId;

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                
            }
            
        }

        public static SqlCommand SetSqlCommandTextAndParameters(SqlCommand sqlCommand, string query, string parameterName, string value)
        {
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.Add(parameterName, SqlDbType.VarChar);
            sqlCommand.Parameters[parameterName].Value = value;

            return sqlCommand;
        }
    }
}

