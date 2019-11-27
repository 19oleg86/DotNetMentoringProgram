using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using NorthwindDAL;
using System.Collections.Specialized;

namespace MainWebHost
{
    public partial class MainHost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
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
    }
}