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
        public IEnumerable<Order> GetOrders()
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }
        }
    }
}
