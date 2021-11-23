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
            //var file = path + "\\Datasets\\users.json";
            //var datasetFile = path + "\\Datasets\\products.json";
            var datasetFile = path + "\\Datasets\\categories.json";

            var inputJson = File.ReadAllText(datasetFile);

            //Console.WriteLine(ImportUsers(context, inputJson));
            //Console.WriteLine(ImportProducts(context, inputJson));
            Console.WriteLine(ImportCategories(context, inputJson));
        }

        //Problem 02
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

        //Problem 03
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> productObjects = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            foreach (var product in productObjects)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            return $"Successfuly imported {context.Products.Count()}";
        }

        //Problem 04
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var dbContext = context.Categories;

            List<Category> categoriesObjects = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            foreach (var category in categoriesObjects)
            {
                if (category.Name != null)
                {
                    dbContext.Add(category);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {dbContext.Count()}";
        }
    }
}