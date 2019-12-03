using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Task1Linq2DB.Models;
using LinqToDB;
using System.Data.SqlClient;
using System.Data;

namespace Task1Linq2DB
{
    public class DbNorthwind : DataConnection
    {
        public DbNorthwind() : base("Northwind")
        {}

        public ITable<Employee> Employees => GetTable<Employee>();

        public ITable<Order> Orders => GetTable<Order>();

        public ITable<Product> Products => GetTable<Product>();

        public ITable<Region> Regions => GetTable<Region>();

        public ITable<Category> Categories => GetTable<Category>();

        public ITable<Supplier> Suppliers => GetTable<Supplier>();

        public ITable<Shipper> Shippers => GetTable<Shipper>();
    }
}
