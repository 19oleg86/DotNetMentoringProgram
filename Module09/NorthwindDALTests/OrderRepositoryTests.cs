using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindDAL;
using NUnit.Framework;

namespace NorthwindDALTests
{
    [TestClass]
    public class OrderRepositoryTests
    {
        string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
        string sqlConnection = "System.Data.SqlClient";
        [TestMethod]
        public void GetOrders_IEnumerableOfOrderReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);

            //Act
            var actual = repository.GetOrders();

            //Assert
            NUnit.Framework.Assert.That(actual, Is.TypeOf<List<Order>>());
        }

        [TestMethod]
        public void GetOrderDetails_OrderReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);

            //Act
            var actual = repository.GetOrderDetails(10248);

            //Assert
            NUnit.Framework.Assert.That(actual, Is.TypeOf<Order>());
        }

        [TestMethod]
        public void AddNewOrder_AffectedRowsNumberReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int expected = 1;

            //Act
            var actual = repository.AddNewOrder("CHOPS", DateTime.Now, DateTime.Now);

            //Assert
            NUnit.Framework.Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void AddNewOrderWithCustomerIdAndRequiredDate_AffectedRowsNumberReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int expected = 1;

            //Act
            var actual = repository.AddNewOrder("CHOPS", DateTime.Now);

            //Assert
            NUnit.Framework.Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void AddNewOrderWithCustomerId_AffectedRowsNumberReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int expected = 1;

            //Act
            var actual = repository.AddNewOrder("CHOPS");

            //Assert
            NUnit.Framework.Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void UpdateOrder_AffectedRowsNumberReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int expected = 1;

            //Act
            var actual = repository.UpdateOrder(10260, "ERNSH");

            //Assert
            NUnit.Framework.Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CreateDbConnection_DbConnectionReturned()
        {
            //Arrange
            OrderRepository repository = new OrderRepository(connectionString, sqlConnection);

            //Act
            var actual = OrderRepository.connectionToDB;

            //Assert
            NUnit.Framework.Assert.That(actual, Is.TypeOf<SqlConnection>());
        }

        [TestMethod]
        public void PutOrderToInProgress_DbDataReaderReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);

            //Act
            var actual = repository.PutOrderToInProgress(10262);

            //Assert
            NUnit.Framework.Assert.That(actual, Is.TypeOf<SqlDataReader>());
        }

        [TestMethod]
        public void GetOrderStatisticFromSP_DbDataReaderReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);

            //Act
            var actual = repository.GetOrderStatisticFromSP(10262);

            //Assert
            NUnit.Framework.Assert.That(actual, Is.TypeOf<SqlDataReader>());
        }

        [TestMethod]
        public void DeleteOrder_AffectedRowsNumberReturned()
        {
            //Arrange
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            repository.AddNewOrder("LILAS");
            repository = new OrderRepository(connectionString, sqlConnection);
            int lastOrderId = repository.GetLastOrderId();
            int expected = 1;

            //Act
            repository = new OrderRepository(connectionString, sqlConnection);
            var actual = repository.DeleteOrder(lastOrderId);

            //Assert
            NUnit.Framework.Assert.AreEqual(actual, expected);
        }
    }


}
