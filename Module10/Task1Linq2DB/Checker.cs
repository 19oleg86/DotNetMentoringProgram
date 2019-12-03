using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Linq2DB.Models;
using LinqToDB;
using LinqToDB.Common;
using System.Linq;
using System.Data.SqlClient;

namespace Task1Linq2DB
{
    [TestClass]
    public class Checker
    {
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
    }
}
