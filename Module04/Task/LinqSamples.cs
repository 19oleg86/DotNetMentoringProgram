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
        [Description("This sample returns all customers whose sum of all orders is bigger than exact value (fir exampe bigger than 10 000)")]

        public void Linq3()
        {
            var allCustomersWithSells = from customer in dataSource.Customers
                                        group customer by customer.CompanyName into g
                                        select new { Name = g.Key, sumOrders = g.Select(x => x.Orders) };

            foreach (var customer in allCustomersWithSells)
            {
                foreach (Order[] order in customer.sumOrders)
                {
                    IEnumerable<decimal> totals = order.Select(x => x.Total);
                    decimal allTotals = 0;
                    foreach (var total in totals)
                    {
                        allTotals += total;
                    }
                    if (allTotals > 10000)
                    {
                        Console.Write($"{customer.Name}: ");
                        Console.WriteLine(allTotals);
                    }
                }
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 4")]
        [Description("This sample returns list of suppliers for all customers from the same country and city")]
        public void Linq4()
        {
            var allSuppliers = from supplier in dataSource.Suppliers
                               from customer in dataSource.Customers
                               where supplier.Country == customer.Country
                               where supplier.City == customer.City
                               select new { Supplier = supplier.SupplierName, Customer = customer.CompanyName };
            foreach (var supplier in allSuppliers)
            {
                Console.WriteLine($"Customer \"{supplier.Customer}\" and Supplier \"{supplier.Supplier}\" are located in the same Country and City");
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 4 (grouped)")]
        [Description("This sample returns list of suppliers for all customers from the same country and city grouped by suppliers")]
        public void Linq4Grouped()
        {
            var allGroupedPeople = from supplier in dataSource.Suppliers
                                   from customer in dataSource.Customers
                                   where supplier.Country == customer.Country
                                   where supplier.City == customer.City
                                   group supplier by supplier.SupplierName into g
                                   select new
                                   {
                                       GroupedSupplier = g.Key,
                                       WholeSupplier = g,
                                       Customer = from c in dataSource.Customers
                                                  where c.Country == dataSource.Suppliers.ToString()
                                                  select c
                                   };

            foreach (var sup in allGroupedPeople)
            {
                Console.WriteLine(sup.GroupedSupplier);
                foreach (var customer in sup.Customer)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }

        }

        [Category("Restriction Operators")]
        [Title("Where - Task 5")]
        [Description("This sample returns list of customers who had orders bigger than exact sum")]
        public void Linq5()
        {
            var allCustomers = from customer in dataSource.Customers
                               from allOrders in customer.Orders
                               where allOrders.Total > 10000
                               group customer by customer.CompanyName into g
                               select new { Name = g.Key, Customer = g };
            Console.WriteLine($"Customers who had orders where cost is more than 10 000:");
            foreach (var cust in allCustomers)
            {
                Console.WriteLine($"Customer {cust.Name} ");

            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 6")]
        [Description("This sample returns list of customers and from what month and year they became customers")]
        public void Linq6()
        {
            var selectedCustomers = from customer in dataSource.Customers
                                    from order in customer.Orders
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

    }
}
