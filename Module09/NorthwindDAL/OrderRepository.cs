using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;

namespace NorthwindDAL
{
    public class OrderRepository : IOrderRepository
    {
        public static DbConnection connectionToDB;

        public OrderRepository(string connectionString, string providerName)
        {
            connectionToDB = CreateDbConnection(providerName, connectionString);
        }

        static DbConnection CreateDbConnection(string providerName, string connectionString)
        {
            DbConnection connection = null;
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            return connection;
        }

        public DbDataReader PutOrderToInProgress(int orderId)
        {
            DbDataReader dbDataReader = null;
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Orders SET OrderDate = @OrderDate WHERE OrderID = @OrderID";
                    command.CommandType = CommandType.Text;
                    var paramOrderDate = command.CreateParameter();
                    paramOrderDate.ParameterName = "@OrderDate";
                    paramOrderDate.Value = DateTime.Now;
                    command.Parameters.Add(paramOrderDate);

                    var paramOrderID = command.CreateParameter();
                    paramOrderID.ParameterName = "@OrderID";
                    paramOrderID.Value = orderId;
                    command.Parameters.Add(paramOrderID);

                    int affectedRows = command.ExecuteNonQuery();
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM  dbo.Orders WHERE OrderID = @OrderID";
                    command.CommandType = CommandType.Text;

                    var paramOrderID = command.CreateParameter();
                    paramOrderID.ParameterName = "@OrderID";
                    paramOrderID.Value = orderId;
                    command.Parameters.Add(paramOrderID);

                    dbDataReader = command.ExecuteReader();
                }
            }
            return dbDataReader;
        }

        public int DeleteOrder(int orderID)
        {
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Orders WHERE OrderID = @OrderID";
                    command.CommandType = CommandType.Text;
                    var paramOrderID = command.CreateParameter();
                    paramOrderID.ParameterName = "@OrderID";
                    paramOrderID.Value = orderID;
                    command.Parameters.Add(paramOrderID);
                    
                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows;
                }
            }
        }

        public int UpdateOrder(int orderID, string newCustomerId)
        {
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Orders SET CustomerID = @CustomerId WHERE OrderID = @OrderID";
                    command.CommandType = CommandType.Text;
                    var paramOrderID = command.CreateParameter();
                    paramOrderID.ParameterName = "@OrderID";
                    paramOrderID.Value = orderID;
                    command.Parameters.Add(paramOrderID);
                    var paramNewCustomerId = command.CreateParameter();
                    paramNewCustomerId.ParameterName = "@CustomerId";
                    paramNewCustomerId.Value = newCustomerId;
                    command.Parameters.Add(paramNewCustomerId);

                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows;
                }
            }
        }

        public int AddNewOrder(string customerId, DateTime? orderDate, DateTime? shippedDate)
        {
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Orders (CustomerID, OrderDate, ShippedDate) VALUES (@CustomerID, @OrderDate, @ShippedDate)";
                    command.CommandType = CommandType.Text;
                    var paramCustomerID = command.CreateParameter();
                    paramCustomerID.ParameterName = "@CustomerID";
                    paramCustomerID.Value = customerId;
                    command.Parameters.Add(paramCustomerID);
                    var paramOrderDate = command.CreateParameter();
                    paramOrderDate.ParameterName = "@OrderDate";
                    paramOrderDate.Value = orderDate ?? null;
                    command.Parameters.Add(paramOrderDate);
                    var paramShippedDate = command.CreateParameter();
                    paramShippedDate.ParameterName = "@ShippedDate";
                    paramShippedDate.Value = shippedDate ?? null;
                    command.Parameters.Add(paramShippedDate);

                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows;
                }
            }
        }

        public int AddNewOrder(string customerId, DateTime? requiredDate)
        {
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Orders (CustomerID, RequiredDate) VALUES (@CustomerID, @RequiredDate)";
                    command.CommandType = CommandType.Text;
                    var paramCustomerID = command.CreateParameter();
                    paramCustomerID.ParameterName = "@CustomerID";
                    paramCustomerID.Value = customerId;
                    command.Parameters.Add(paramCustomerID);
                    var paramRequiredDate = command.CreateParameter();
                    paramRequiredDate.ParameterName = "@RequiredDate";
                    paramRequiredDate.Value = requiredDate ?? null;
                    command.Parameters.Add(paramRequiredDate);

                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows;
                }
            }
        }

        public int AddNewOrder(string customerId)
        {
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Orders (CustomerID) VALUES (@CustomerID)";
                    command.CommandType = CommandType.Text;
                    var paramCustomerID = command.CreateParameter();
                    paramCustomerID.ParameterName = "@CustomerID";
                    paramCustomerID.Value = customerId;
                    command.Parameters.Add(paramCustomerID);
                    
                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows;
                }
            }

        }

        public Order GetOrderDetails(int orderID)
        {
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ords.OrderID FROM dbo.Orders AS ords WHERE ords.OrderID = @id; " +
                                          "SELECT ordt.ProductID FROM  dbo.[Order Details] AS ordt WHERE ordt.OrderID = @id; " +
                                          "SELECT prds.ProductName FROM Products as prds, [Order Details] WHERE prds.ProductID = dbo.[Order Details].ProductID AND dbo.[Order Details].OrderID = @id";
                    command.CommandType = CommandType.Text;
                    var paramID = command.CreateParameter();
                    paramID.ParameterName = "@id";
                    paramID.Value = orderID;
                    command.Parameters.Add(paramID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows) return null;
                        reader.Read();

                        Order order = new Order();

                        order.OrderID = (int)reader["OrderID"];

                        reader.NextResult();
                        order.Details = new List<OrderDetails>();

                        var detail = new OrderDetails();
                        while (reader.Read())
                        {
                            detail = new OrderDetails();
                            detail.ProductID = (int)reader["ProductID"];
                            order.Details.Add(detail);
                        }
                        reader.NextResult();

                        order.Details.FirstOrDefault().Products = new List<Product>();
                        var product = new Product();
                        while (reader.Read())
                        {
                            product = new Product();
                            product.ProductName = (string)reader["ProductName"];
                            order.Details.FirstOrDefault().Products.Add(product);
                        }
                        return order;
                    }
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            var resultOrders = new List<Order>();
            using (var connection = connectionToDB)
            {
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
                            order.EmployeeID = (reader["EmployeeID"] as int?) ?? null;
                            order.OrderDate = (reader["OrderDate"] as DateTime?) ?? null;
                            order.RequiredDate = (reader["RequiredDate"] as DateTime?) ?? null;
                            order.ShippedDate = (reader["ShippedDate"] as DateTime?) ?? null;
                            order.ShipVia = (reader["ShipVia"] as int?) ?? null;
                            order.Freight = (decimal)reader["Freight"];
                            order.ShipName = (reader["ShipName"] as string) ?? null;
                            order.ShipAddress = (reader["ShipAddress"] as string) ?? null;
                            order.ShipCity = (reader["ShipCity"] as string) ?? null;
                            order.ShipRegion = (reader["ShipRegion"] as string) ?? null;
                            order.ShipPostalCode = (reader["ShipPostalCode"] as string) ?? null;
                            order.ShipCountry = (reader["ShipCountry"] as string) ?? null;
                            if (order.OrderDate == null && order.RequiredDate == null && order.ShippedDate == null)
                            {order.OrderStatus = OrderStatus.New; }
                            else if (order.OrderDate == null && order.ShippedDate == null)
                            { order.OrderStatus = OrderStatus.InProgress; }
                            else { order.OrderStatus = OrderStatus.Done; }

                            resultOrders.Add(order);
                        }
                    }
                }
            }
            return resultOrders;
        }

        public DbDataReader GetOrderStatisticFromSP(int orderId)
        {
            DbDataReader procResult;
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.CustOrderHist";
                    command.CommandType = CommandType.StoredProcedure;
                    var paramId = command.CreateParameter();
                    paramId.ParameterName = "@CustomerID";
                    paramId.Value = orderId;
                    command.Parameters.Add(paramId);

                    procResult = command.ExecuteReader();
                    return procResult;
                }
            }
        }

        public int GetLastOrderId()
        {
            int lastOrderId;
            using (var connection = connectionToDB)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT MAX(OrderID) FROM Orders";
                    command.CommandType = CommandType.Text;

                    lastOrderId = (int)command.ExecuteScalar();
                }
                return lastOrderId;
            }
        }
    }

        public enum OrderStatus
        {
            New = 0,
            InProgress = 1,
            Done = 2
        }
}
