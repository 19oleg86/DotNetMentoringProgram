using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindDAL;

namespace NorthwindDALTests
{
    [TestClass]
    public class OrderRepositoryTests
    {
        [TestMethod]
        public void GetOrders_IEnumerableOfOrderReturned()
        {
            //Arrange
            string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
            string sqlConnection = "System.Data.SqlClient";
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            var expected = new List<Order>();
            Order order;

            //Act
            var actual = repository.GetOrders();

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(actual, order.);
        }
    }
}
