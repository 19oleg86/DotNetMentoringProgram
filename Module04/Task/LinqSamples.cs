﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
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
                                    where customer.Orders.Any(x => x.OrderDate != null)
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
        [Description("All products grouped by category, inside grouped by UnitInStock and sorted by UnitPrice inside the last gropu")]
        public void Linq9()
        {
            var groupedProducts = dataSource.Products.GroupBy(x => new { x.Category, x.UnitsInStock }, (key, group) => new { Key1 = key.Category, Key2 = key.UnitsInStock, Other = group }).OrderBy(x => x.Other.Select(y => y.UnitPrice));

            foreach (var gp in groupedProducts)
            {
                Console.WriteLine($"{gp.Key1}");
                foreach (var cats in gp.Other)
                {
                    Console.WriteLine($"{gp.Key2}");
                    foreach (var units in gp.Other)
                    {
                        Console.WriteLine($"{units.ProductName} - {units.UnitPrice}");
                    }
                }

            }
        }
    }
}
