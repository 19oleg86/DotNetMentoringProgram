using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Task2EntityFramework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new NorthwindDB())
            {
                var query = from o in context.Orders
                            from od in context.Order_Details
                            from p in context.Products
                            from c in context.Customers
                            where o.OrderID == od.OrderID && od.ProductID == p.ProductID && o.CustomerID == c.CustomerID
                            select new { Order = o.OrderID, Customer = c.CompanyName, Product = p.ProductName };

                foreach(var order in query)
                    Console.WriteLine("Order: {0}, Customer: {1}, Product: {2}",order.Order, order.Customer, order.Product);
            }
        }
    }
}
