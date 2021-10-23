using System;
using System.Collections.Generic;
using System.Text;

namespace _02_VillainNames
{
    public static class Queries
    {
        public const string GET_VILLAIN_NAMES = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                    FROM Villains AS v 
                                                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                GROUP BY v.Id, v.Name 
                                                  HAVING COUNT(mv.VillainId) > 3
                                                ORDER BY COUNT(mv.VillainId) DESC";

        public const string GET_VILLAIN_BY_ID = @"SELECT
	                                                    [Name]
                                                    FROM Villains
                                                    WHERE Id = @Id";

        public const string GET_ALL_MINIONS_OF_A_VILLAIN_BY_ID = @"SELECT
	                                                                    ROW_NUMBER() OVER (ORDER BY m.[Name] ASC) AS [Row]
	                                                                    ,m.[Name]
	                                                                    ,m.Age
                                                                    FROM Minions AS m
                                                                    JOIN MinionsVillains AS mv ON mv.MinionId = m.Id
                                                                    JOIN Villains AS v ON v.Id = mv.VillainId
                                                                    WHERE v.Id = @Id";
        
        public const string GET_MINION_ID_BY_NAME = @"SELECT Id FROM Minions WHERE Name = @Name";

        public const string GET_VILLAIN_ID_BY_NAME = @"SELECT Id FROM Villains WHERE Name = @Name";

        public const string GET_TOWN_ID_BY_NAME = @"SELECT Id FROM Towns WHERE Name = @townName";

        public const string ADD_TOWN_TO_DB = @"INSERT INTO Towns (Name) VALUES (@townName)";

        public const string ADD_VILLAIN_TO_DB = @"INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@Name, 4)";

        public const string ADD_MINION_TO_DB = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@Name, @Age, @TownId)";

        public const string ADD_MINION_TO_VILLAIN = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@MinionId, @VillainId)";
    }
}
