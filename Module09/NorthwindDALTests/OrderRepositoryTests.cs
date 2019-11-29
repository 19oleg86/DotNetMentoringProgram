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
        [TestMethod]
        public void GetOrders_IEnumerableOfOrderReturned()
        {
            //Arrange
            string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
            string sqlConnection = "System.Data.SqlClient";
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
            string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
            string sqlConnection = "System.Data.SqlClient";
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
            string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
            string sqlConnection = "System.Data.SqlClient";
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int expected = 1;

            //Act
            var actual = repository.AddNewOrder("CHOPS", DateTime.Now, DateTime.Now);

            //Assert
            NUnit.Framework.Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void UpdateOrder_AffectedRowsNumberReturned()
        {
            //Arrange
            string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
            string sqlConnection = "System.Data.SqlClient";
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
            string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
            string sqlConnection = "System.Data.SqlClient";
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
            string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
            string sqlConnection = "System.Data.SqlClient";
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);

            //Act
            var actual = repository.PutOrderToInProgress(10262);

            //Assert
            NUnit.Framework.Assert.That(actual, Is.TypeOf<SqlDataReader>());
        }

        //[TestMethod]
        //public void DeleteOrder_AffectedRowsNumberReturned()
        //{
        //    //Arrange
        //    string connectionString = "data source=.; database = Northwind; integrated security=SSPI";
        //    string sqlConnection = "System.Data.SqlClient";
        //    IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
        //    int expected = 1;

        //    //Act
        //    var actual = repository.DeleteOrder(11086);

        //    //Assert
        //    NUnit.Framework.Assert.AreEqual(actual, expected);
        //    repository = new OrderRepository(connectionString, sqlConnection);
        //    repository.AddNewOrder("DRACD", DateTime.Now, DateTime.Now);
        //}
    }


}
