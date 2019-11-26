using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace NorthwindDAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbProviderFactory providerFactory;
        private readonly string connectionString;
        DbConnection sqlConnection;

        public OrderRepository(string connectionString, DbConnection sqlConnection)
        {
            this.connectionString = connectionString;
            this.sqlConnection = sqlConnection;
        }
        public IEnumerable<Order> GetOrders()
        {
            var resultOrders = new List<Order>();
            using (var connection = sqlConnection/*providerFactory.CreateConnection()*/)
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM dbo.Orders";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();

                            order.OrderID = (int)reader["OrderID"];
                            order.CustomerID = (string)reader["CustomerID"];
                            order.EmployeeID = (int)reader["EmployeeID"];
                            order.OrderDate = (DateTime)reader["OrderDate"];
                            order.RequiredDate = (DateTime)reader["RequiredDate"];
                            order.ShippedDate = (reader["ShippedDate"] as DateTime?) ?? new DateTime(9999,12,12,23,59,59,999);
                            order.ShipVia = (int)reader["ShipVia"];
                            order.Freight = (decimal)reader["Freight"];
                            order.ShipName = (string)reader["ShipName"];
                            order.ShipAddress = (string)reader["ShipAddress"];
                            order.ShipCity = (string)reader["ShipCity"];
                            order.ShipRegion = (reader["ShipRegion"] as string) ?? "empty";
                            order.ShipPostalCode = (reader["ShipPostalCode"] as string) ?? "empty";
                            order.ShipCountry = (string)reader["ShipCountry"];
                            order.OrderStatus = order.ShippedDate == new DateTime(9999, 12, 12, 23, 59, 59, 999) ? OrderStatus.NotInProgress : OrderStatus.InProgress;

                            resultOrders.Add(order);
                        }
                    }
                }
            }
            return resultOrders;
        }
    }

    public enum OrderStatus
    {
        NotInProgress = 0,
        InProgress = 1
    }
}
