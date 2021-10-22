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
    }
}
