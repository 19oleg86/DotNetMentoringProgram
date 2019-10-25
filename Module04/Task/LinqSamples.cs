// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
    [Title("LINQ Module")]
    [Prefix("Linq")]
    public class LinqSamples : SampleHarness
    {

        private DataSource dataSource = new DataSource();

        [Category("Restriction Operators")]
        [Title("Where - Task 1 (Example)")]
        [Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
        public void Linq1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums =
                from num in numbers
                where num < 5
                select num;

            Console.WriteLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 2 (Example)")]
        [Description("This sample returns all presented in market products")]

        public void Linq2()
        {
            var products =
                from p in dataSource.Products
                where p.UnitsInStock > 0
                select p;

            foreach (var p in products)
            {
                ObjectDumper.Write(p);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 3")]
        [Description("This sample returns all customers whose sum of all orders is bigger than exact value (for example bigger than 10 000)")]

        public void Linq3()
        {
            var allCustomersWithSells = from customer in dataSource.Customers
                                        where customer.Orders.Sum(x => x.Total) > 10000
                                        select new { Name = customer.CompanyName, sumOrders = customer.Orders.Sum(x => x.Total) };
            Console.WriteLine("Customers with sum of all orders more than 10000: ");
            foreach (var customer in allCustomersWithSells)
            {
                Console.WriteLine($"Customer {customer.Name} has sum of all orders: {customer.sumOrders}");
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 4")]
        [Description("This sample returns list of suppliers for all customers from the same country and city")]
        public void Linq4()
        {
            var allSuppliers = from supplier in dataSource.Suppliers
                               from customer in dataSource.Customers
                               where supplier.Country == customer.Country && supplier.City == customer.City
                               select new { Supplier = supplier.SupplierName, Customer = customer.CompanyName };
            foreach (var supplier in allSuppliers)
            {
                Console.WriteLine($"Customer \"{supplier.Customer}\" and Supplier \"{supplier.Supplier}\" are located in the same Country and City");
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 4 (grouped)")]
        [Description("This sample returns list of suppliers for all customers from the same country and city grouped by suppliers")]
        public void Linq4Grouped() // не работает - доделать
        {
            var allGroupedPeople = from supplier in dataSource.Suppliers
                                   from customer in dataSource.Customers
                                   where supplier.Country == customer.Country && supplier.City == customer.City
                                   group supplier by new { supplier.City, supplier.Country } into g
                                   select new
                                   {
                                       SupplierSimilarity = g.Key,
                                       WholeSupplier = g
                                   };

            foreach (var sup in allGroupedPeople)
            {

                Console.WriteLine($" Supplier {sup.WholeSupplier.Select(x => x.SupplierName.ToString())}");
                Console.WriteLine($"{sup.SupplierSimilarity}");
            }

        }

        [Category("Restriction Operators")]
        [Title("Where - Task 5")]
        [Description("This sample returns list of customers who had orders bigger than exact sum")]
        public void Linq5()
        {
            var allCustomers = from customer in dataSource.Customers
                               where customer.Orders.Any(x => x.Total > 10000)
                               select customer;
            Console.WriteLine($"Customers who had orders where cost is more than 10 000:");
            foreach (var cust in allCustomers)
            {
                Console.WriteLine($"Customer {cust.CompanyName} ");
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 6")]
        [Description("This sample returns list of customers and from what month and year they became customers")]
        public void Linq6()
        {
            var selectedCustomers = from customer in dataSource.Customers
                                    where customer.Orders.Any(x => x.OrderDate > DateTime.MinValue)
                                    select new
                                    {
                                        CustomerName = customer.CompanyName,
                                        FirstOrderDate = customer.Orders.Min(y => y.OrderDate)
                                    };

            foreach (var cust in selectedCustomers.Distinct())
            {
                Console.WriteLine($"Customer {cust.CustomerName} bacame customer in {cust.FirstOrderDate}");
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 7")]
        [Description("This sample returns list of customers and from what month and year they became customers sorted by year, month, clients profit from Max to Min and clients name")]
        public void Linq7()
        {
            var selectedCustomers = from customer in dataSource.Customers
                                    from order in customer.Orders
                                    orderby order.OrderDate.Year, order.OrderDate.Month, customer.Orders.Sum(x => x.Total) descending, customer.CompanyName
                                    select new
                                    {
                                        CustomerName = customer.CompanyName,
                                        FirstOrderDate = customer.Orders.Min(y => y.OrderDate),
                                        ClientProfit = customer.Orders.Sum(x => x.Total)
                                    };

            foreach (var cust in selectedCustomers.Distinct())
            {
                Console.WriteLine($"Customer {cust.CustomerName} bacame customer in {cust.FirstOrderDate}, client's profit: {cust.ClientProfit}");
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 8")]
        [Description("Show all the clients that have no numeric postal code, or with not filled region, or without operator code in their phone (without parenthesis in the beginning)")]
        public void Linq8()
        {
            var selectedCustomers = from customer in dataSource.Customers
                                    from order in customer.Orders
                                    where (!string.IsNullOrEmpty(customer.PostalCode) && !customer.PostalCode.Any(char.IsDigit)) || string.IsNullOrEmpty(customer.Region) || !customer.Phone.StartsWith("(")
                                    select new
                                    {
                                        CustomerName = customer.CompanyName,
                                        CustomerPostalCode = customer.PostalCode,
                                        CustomerRegion = customer.Region,
                                        CustomerPhone = customer.Phone
                                    };
            foreach (var customer in selectedCustomers.Distinct())
            {
                Console.WriteLine($"Customer: {customer.CustomerName} - Postal Code: {customer.CustomerPostalCode} - Region: {customer.CustomerRegion} - Phone: {customer.CustomerPhone}");
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 9")]
        [Description("All products grouped by category, inside grouped by UnitInStock and sorted by UnitPrice inside the last group")]
        public void Linq9()
        {
            var groupedCategoryProducts = dataSource.Products.GroupBy(x => x.Category).Select(g => new
            {
                Key1 = g.Key,
                Other = g
                .GroupBy(y => y.UnitsInStock).Select(m => new { Key2 = m.Key, Other2 = m.OrderBy(z => z.UnitPrice) })
            });

            foreach (var gp in groupedCategoryProducts)
            {
                Console.WriteLine($"Category: {gp.Key1}");
                foreach (var uis in gp.Other)
                {
                    Console.WriteLine($" Units In Stock: {uis.Key2}");
                    foreach (var up in uis.Other2)
                    {
                        Console.WriteLine($"  Product: {up.ProductName} - Price: {up.UnitPrice}");
                    }
                }

            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 10")]
        [Description("All products grouped by groups - \"Low Price\", \"Average Price\" and \"High Price\"")]
        public void Linq10()
        {
            string FindOutCost(decimal cost)
            {
                if (cost < 20)
                {
                    return "Low Price (lower than 20)";
                }
                else if (cost >= 20 && cost < 40)
                {
                    return "Average Price (from 20 to 40)";
                }
                else return "High Price (Higher than 40)";
            }

            var groupedProducts = from product in dataSource.Products
                                  group product by FindOutCost(product.UnitPrice) into g
                                  select new { Key = g.Key, Group = g };
            foreach (var gp in groupedProducts)
            {
                Console.WriteLine($"{gp.Key}:");
                foreach (var other in gp.Group)
                {
                    Console.Write($"  {other.ProductName} - ");
                    Console.WriteLine($"{other.UnitPrice}");
                }

            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 11")]
        [Description("Average profit of every city (average order sum of all clients from this city), Average intensity (Average quantity of orders for a client from each city)")]
        public void Linq11()
        {
            var averageCityProfit = from customer in dataSource.Customers
                                    from order in customer.Orders
                                    group customer by customer.City into g
                                    select new
                                    {
                                        g.Key,
                                        AverageSum = g.Select(x => x.Orders).Select(y => y.Average(z => z.Total)).Sum() / g.Select(x => x.Orders).Count()
                                    };
            foreach (var v in averageCityProfit)
            {
                Console.WriteLine("{0} has average profit: ${1:#.##}", v.Key, v.AverageSum);
            }

            Console.WriteLine();

            var averageIntensity = from customer in dataSource.Customers
                                   from order in customer.Orders
                                   group customer by customer.City into k
                                   select new
                                   {
                                       k.Key,
                                       AverageOrders = k.Select(x => x.Orders.Count()).Sum() / k.Count()
                                   };

            foreach (var v in averageIntensity)
            {
                Console.WriteLine($"In {v.Key} an average quantity of orders for one client is equal to: {v.AverageOrders}");
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 12")]
        [Description("Average statistics of clients activity grouped by Month, grouped by Year, grouped by Year and Month")]
        public void Linq12()
        {
            var monthClientActivity = from customer in dataSource.Customers
                                      from order in customer.Orders
                                      group customer by order.OrderDate.Month into g
                                      select new
                                      {
                                          g.Key,
                                          ordersNumber = g.Select(x => x.Orders.Count()).Sum()
                                      };
            foreach (var order in monthClientActivity)
            {
                Console.WriteLine($"In month {order.Key} clients activity was equal to {order.ordersNumber}");

            }

            Console.WriteLine();

            var yearClientActivity = from customer in dataSource.Customers
                                     from order in customer.Orders
                                     group customer by order.OrderDate.Year into g
                                     select new
                                     {
                                         YearKey = g.Key,
                                         ordersNumber = g.Select(x => x.Orders.Count()).Sum()
                                     };
            foreach (var order in yearClientActivity)
            {
                Console.WriteLine($"In {order.YearKey} year clients activity was equal to {order.ordersNumber}");

            }

            Console.WriteLine();

            //var yearMonthClientActivity = dataSource.Customers.GroupBy(x => new{ x.Orders.Select(x => x.OrderDate.Year) }
                                          
            //foreach (var order in yearMonthClientActivity)
            //{
            //    Console.WriteLine($"In {order.Key1} year clients activity was equal to {order.Group}");
            //    foreach (var or in order.Group.Select(x => x.Key2))
            //    {
            //        Console.WriteLine($"In {or}");
            //    }

            //}
        }
    }
}
