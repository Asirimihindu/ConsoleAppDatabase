using ConsoleAppDatabase.Data;
using ConsoleAppDatabase.Models;
using System;
using System.Linq;

namespace ConsoleAppDatabase
{
    class Program
    {
        /// <summary>
        /// Install nuget packages MS Entity framework tools, design and sqlserver 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("This is my First Entity Core Framework application");

            using EntityCoreDbContext context = new EntityCoreDbContext();
            /* Adding new Product data to Products table  in the new Database 
            Product cheeseCake = new Product
            {
                Name = "Cheese Cake",
                Price = 49.99M
            };

            Product fruitSalad = new Product
            {
                Name = "Fruit Salad",
                Price = 14.00M
            };

            context.Products.Add(cheeseCake);
            context.Products.Add(fruitSalad);

            context.SaveChanges();
            */
            var fruitSalad = context.Products.Where(p => p.Name == "Fruit Salad").FirstOrDefault();

            if(fruitSalad is Product)
            {
                fruitSalad.Price = 21.00m; 
            }
            context.SaveChanges();
            /*
            Remove data of product table 
            var fruitSalad = context.Products.Where(p => p.Name == "Fruit Salad").FirstOrDefault();

            if(fruitSalad is Product)
            {
                context.remove(fruitSalad); 
            }
            context.SaveChanges();
             

            */
            // Reading data from the new database 
            var products = from product in context.Products
                           where product.Price > 20.00m 
                           select product;
            foreach(Product p in products)
            {
                Console.WriteLine($"Id:    {p.Id}");
                Console.WriteLine($"Name:  {p.Name}");
                Console.WriteLine($"Price: {p.Price}");
                Console.WriteLine(new string('-',20));
            }


        }
    }
}
