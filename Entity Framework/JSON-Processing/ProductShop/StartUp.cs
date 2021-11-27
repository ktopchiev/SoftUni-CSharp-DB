using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Dtos.OutputDtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //var workingDirectory = Environment.CurrentDirectory;
            //var path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            //var file = path + "\\Datasets\\users.json";
            //var datasetFile = path + "\\Datasets\\products.json";
            //var datasetFile = path + "\\Datasets\\categories.json";
            //var datasetFile = path + "\\Datasets\\categories-products.json";

            //var inputJson = File.ReadAllText(datasetFile);

            //Console.WriteLine(ImportUsers(context, inputJson));
            //Console.WriteLine(ImportProducts(context, inputJson));
            //Console.WriteLine(ImportCategories(context, inputJson));
            //Console.WriteLine(ImportCategoryProducts(context, inputJson));
            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        ////Problem 01
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

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> productObjects = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            foreach (var product in productObjects)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }

        //Problem 03
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

        ////Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var table = context.CategoryProducts;

            List<CategoryProduct> categoryProductsObjects = JsonConvert
                .DeserializeObject<List<CategoryProduct>>(inputJson);

            foreach (var cpo in categoryProductsObjects)
            {
                table.Add(cpo);
            }

            context.SaveChanges();

            return $"Successfully imported {table.Count()}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Include(p => p.Seller)
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    p.Seller
                })
                .OrderBy(p => p.Price)
                .ToList();

            var productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsJson;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new UserSoldProduct
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new SoldProduct
                        {
                            Name = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName,
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
            };

            var usersJson = JsonConvert.SerializeObject(users, jsonSettings);

            return usersJson;
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .ThenBy(x => x.Name)
                .Select(c => new CategoryByProductsCountDto
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = Math.Round(c.CategoryProducts.Average(p => p.Product.Price), 2),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price),
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };

            var categoriesJson = JsonConvert.SerializeObject(categories, jsonSettings);

            return categoriesJson;
        }
    }
}