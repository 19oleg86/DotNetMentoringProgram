using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace NorthwindDAL
{
    public class OrderRepository : IOrderRepository
    {
        DbConnection connectionToDB;

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

        public int AddNewOrder(string customerId, DateTime orderDate, DateTime shippedDate)
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
                    paramOrderDate.Value = orderDate;
                    command.Parameters.Add(paramOrderDate);
                    var paramShippedDate = command.CreateParameter();
                    paramShippedDate.ParameterName = "@ShippedDate";
                    paramShippedDate.Value = shippedDate;
                    command.Parameters.Add(paramShippedDate);

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
                            order.EmployeeID = (int)reader["EmployeeID"];
                            order.OrderDate = (DateTime)reader["OrderDate"];
                            order.RequiredDate = (DateTime)reader["RequiredDate"];
                            order.ShippedDate = (reader["ShippedDate"] as DateTime?) ?? null;
                            order.ShipVia = (int)reader["ShipVia"];
                            order.Freight = (decimal)reader["Freight"];
                            order.ShipName = (string)reader["ShipName"];
                            order.ShipAddress = (string)reader["ShipAddress"];
                            order.ShipCity = (string)reader["ShipCity"];
                            order.ShipRegion = (reader["ShipRegion"] as string) ?? null;
                            order.ShipPostalCode = (reader["ShipPostalCode"] as string) ?? null;
                            order.ShipCountry = (string)reader["ShipCountry"];
                            order.OrderStatus = order.ShippedDate == null ? OrderStatus.NotInProgress : OrderStatus.InProgress;

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
