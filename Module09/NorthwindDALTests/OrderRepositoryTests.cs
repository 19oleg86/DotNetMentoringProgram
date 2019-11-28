using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var mock = new Mock<IOrderRepository>();
            mock.Setup(a => a.GetOrders()).Returns(new List<Order>());
            IOrderRepository orderRepository = new OrderRepository(mock.Object);

            //Act
            List<Order> result = orderRepository.GetOrders() as List<Order>;

            //Assert
            Assert.IsNotNull(result);
            Assert.
        }
    }
}
