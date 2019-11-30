using System;
using System.Collections.Generic;
using System.Data.Common;

namespace NorthwindDAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();

        Order GetOrderDetails(int orderID);

        DbDataReader GetOrderStatisticFromSP(int orderId);

        int AddNewOrder(string customerId, DateTime? orderDate, DateTime? shippedDate);

        int AddNewOrder(string customerId, DateTime? requiredDate);

        int AddNewOrder(string customerId);

        int UpdateOrder(int orderID, string newCustomerId);

        int DeleteOrder(int orderID);

        DbDataReader PutOrderToInProgress(int orderId);

        int GetLastOrderId();
    }
}
