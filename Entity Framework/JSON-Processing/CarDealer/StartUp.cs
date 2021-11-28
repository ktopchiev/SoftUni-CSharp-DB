using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
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
            //var jsonFile1 = "suppliers.json";
            //var jsonFile2 = "parts.json";
            //var jsonFile3 = "cars.json";
            //var jsonFile4 = "customers.json";
            //var jsonFile5 = "sales.json";

            //var jsonPath1 = $"{currentDirectory}\\Datasets\\{jsonFile1}";
            //var jsonPath2 = $"{currentDirectory}\\Datasets\\{jsonFile2}";
            //var jsonPath3 = $"{currentDirectory}\\Datasets\\{jsonFile3}";
            //var jsonPath4 = $"{currentDirectory}\\Datasets\\{jsonFile4}";
            //var jsonPath5 = $"{currentDirectory}\\Datasets\\{jsonFile5}";

            //string json1 = File.ReadAllText(jsonPath1);
            //string json2 = File.ReadAllText(jsonPath2);
            //string json3 = File.ReadAllText(jsonPath3);
            //string json4 = File.ReadAllText(jsonPath4);
            //string json5 = File.ReadAllText(jsonPath5);

            var context = new CarDealerContext();

            //Console.WriteLine(ImportSuppliers(context, json1));
            //Console.WriteLine(ImportParts(context, json2));
            //Console.WriteLine(ImportCars(context, json3));
            //Console.WriteLine(ImportCustomers(context, json4));
            //Console.WriteLine(ImportSales(context, json5));
        }

        //Problem 08 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersList = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliersList);

            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}.";
        }

        //Problem 09 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliersIds = context.Suppliers.Select(x => x.Id).ToList();

            IEnumerable<Part> partsList = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson);

            partsList = partsList.Where(p => suppliersIds.Any(s => s == p.SupplierId));

            context.Parts.AddRange(partsList);

            context.SaveChanges();

            return $"Successfully imported { context.Parts.Count()}.";
        }

        //Problem 10 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsList = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (var car in carsList)
            {
                Car newCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TraveledDistance
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    newCar.PartCars.Add(new PartCar
                    {
                        Car = newCar,
                        PartId = partId
                    });
                }

                cars.Add(newCar);
            }

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        //Problem 11 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }

        //Problem 12 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<Sale> sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }
    }
}