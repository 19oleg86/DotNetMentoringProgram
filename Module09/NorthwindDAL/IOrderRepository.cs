using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();

        Order GetOrderDetails(int orderID);

        int AddNewOrder(string customerId, DateTime orderDate, DateTime shippedDate);

        int UpdateOrder(int orderID, string newCustomerId);

        int DeleteOrder(int orderID);
    }
}
