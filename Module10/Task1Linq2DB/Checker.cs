using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Linq2DB.Models;
using LinqToDB;
using LinqToDB.Common;
using System.Linq;
using System.Data.SqlClient;
using LinqToDB.Data;

namespace Task1Linq2DB
{
    [TestClass]
    public class Checker
    {
        // Requests
        [TestMethod]
        public void GetProductsWithCategoryAndSupplier()
        {
            using (var connection = new DbNorthwind())
            {
                var query = from p in connection.Products
                            from c in connection.Categories
                            from s in connection.Suppliers
                            where p.CategoryID == c.CategoryID && p.SupplierID == s.SupplierID
                            select new { Product = p.ProductName, Category = c.CategoryName, Supplier = s.CompanyName };
                foreach (var product in query)
                Console.WriteLine($"Product: {product.Product}, Category: {product.Category}, Supplier: {product.Supplier}");
            };
        }

        [TestMethod]
        public void GetEmployeesWithRegion()
        {
            using (var connection = new DbNorthwind())
            {
                var query = from e in connection.Employees
                            where e.Region == "WA"
                            select e;
                foreach (var employee in query)
                    Console.WriteLine($"EmployeeId: {employee.EmployeeID}, Employee First Name: {employee.FirstName}, Employee Last Name: {employee.LastName} " +
                        $"Employee Title: {employee.Title}, Employee Region: {employee.Region}");
            };
        }

        [TestMethod]
        public void GetRegionsAndEmployees()
        {
            using (var connection = new DbNorthwind())
            {
                var query = from e in connection.Employees
                            group e by e.City into g
                            select new { City = g.Key, Count = g.Count() };

                foreach (var employee in query)
                    Console.WriteLine($"City: {employee.City}, Number of Employees: {employee.Count}");
                        
            };
        }

        [TestMethod]
        public void GetEmployeesAndShippers()
        {
            using (var connection = new DbNorthwind())
            {
                var query = from e in connection.Employees
                            from o in connection.Orders
                            from s in connection.Shippers
                            where o.EmployeeID == e.EmployeeID && o.ShipVia == s.ShipperID
                            select new { Employee = e.FirstName,Order = o.OrderID, Shipper = s.CompanyName };

                foreach (var employee in query)
                    Console.WriteLine($"Employee: {employee.Employee} with order No: {employee.Order} worked with Shipper: {employee.Shipper}");
            };
        }

        // Changes
        [TestMethod]
        public void AddEmployeeWithTerritory()
        {
            using (var connection = new DbNorthwind())
            {
                connection.Employees
                    .Value(p => p.FirstName, "First Name")
                    .Value(p => p.LastName, "Last Name")
                    .Value(p => p.Title, "Representative")
                    .Value(p => p.Region, "WA").InsertWithInt32Identity();
            };
        }

        [TestMethod]
        public void MoveProductToAnotherCategory()
        {
            using (var connection = new DbNorthwind())
            {
                connection.Products
                    .Where(p => p.ProductID == 10)
                    .Set(p => p.CategoryID, 2)
                    .Update();
            };
        }

        [TestMethod]
        public void AddListOfProductsWithSupplierAndCategory()
        {
            var list = new List<Product>()
            {
                new Product() { ProductName = "Product Name1", CategoryID = 3, SupplierID = 15 },
                new Product() { ProductName = "Product Name2", CategoryID = 35, SupplierID = 18 },
                new Product() { ProductName = "Product Name3", CategoryID = 11, SupplierID = 33 }
            };
            using (var connection = new DbNorthwind())
            {
                connection.BulkCopy(list);
            };
        }

        [TestMethod]
        public void ChangeProduct()
        {
            using (var connection = new DbNorthwind())
            {
                var orders = from o in connection.Orders
                             select o;

                if (orders.Any(x => x.ShippedDate == null))
                {
                    connection.OrderDetails
                        .Where(x => x.OrderID == orders.FirstOrDefault().OrderID)
                        .Set(p => p.ProductID, 10)
                        .Update();
                }
            };
        }

    }
}
