using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            var workingDirectory = Environment.CurrentDirectory;
            var path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var file = path + "\\Datasets\\users.json";

            var inputJson = File.ReadAllText(file);


            Console.WriteLine(ImportUsers(context, inputJson));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            var tableUsers = context.Users;

            foreach (var user in users)
            {
                tableUsers.Add(user);
            }

            context.SaveChanges();
            return $"Successfully imported { context.Users.Count()}";
        }
    }
}