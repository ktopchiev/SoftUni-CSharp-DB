using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var currentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var jsonPath = currentDirectory + "\\Datasets\\suppliers.json";

            string json = File.ReadAllText(jsonPath);

            var context = new CarDealerContext();


            Console.WriteLine(ImportSuppliers(context, json));
        }

        //Problem 08 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersList = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliersList);
            
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}.";
        }
    }
}