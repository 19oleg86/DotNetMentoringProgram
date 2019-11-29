using System;
using System.Collections.Generic;
using System.Configuration;
using NorthwindDAL;
using System.Collections.Specialized;

namespace MainWebHost
{
    public partial class MainHost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("MyDictionary");

        protected void btnGetOrders_Click(object sender, EventArgs e)
        { 
            string sqlConnection = section["SqlProvider"];
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            IEnumerable<Order> listOfOrders = repository.GetOrders();
            grvAllOrders.DataSource = listOfOrders;
            grvAllOrders.DataBind();
        }

        protected void btnShowOrderDetails_Click(object sender, EventArgs e)
        {
            string sqlConnection = section["SqlProvider"];
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int orderId = int.Parse(txtOrderId.Text);
            Order orderResult = repository.GetOrderDetails(orderId);
        }

        protected void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            string sqlConnection = section["SqlProvider"];
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int result = repository.AddNewOrder("TOMSP", DateTime.Now, DateTime.Now);
        }

        protected void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            string sqlConnection = section["SqlProvider"];
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int result = repository.UpdateOrder(10252, "TOMSP");
        }

        protected void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            string sqlConnection = section["SqlProvider"];
            IOrderRepository repository = new OrderRepository(connectionString, sqlConnection);
            int result = repository.DeleteOrder(10317);
        }
    }
}