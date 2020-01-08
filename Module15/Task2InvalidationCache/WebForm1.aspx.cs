using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task2InvalidationCache
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //<script runat = "server" >
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            SqlCacheDependency SqlDep = null;

            if (Cache["SqlSource"] == null)
            {
                try
                {
                    SqlDep = new SqlCacheDependency("Northwind", "Categories");
                }
                catch (DatabaseNotEnabledForNotificationException exDBDis)
                {
                    try
                    {
                        SqlCacheDependencyAdmin.EnableNotifications(connectionString);
                    }
                    catch (UnauthorizedAccessException exPerm)
                    {
                        Response.Redirect(".\\ErrorPage.html");
                    }
                }

                catch (TableNotEnabledForNotificationException exTabDis)
                {
                    try
                    {
                        SqlCacheDependencyAdmin.EnableTableForNotifications("Northwind", "Categories");
                    }

                    // If a SqlException is thrown, redirect to an error page. 
                    catch (SqlException exc)
                    {
                        Response.Redirect(".\\ErrorPage.htm");
                    }
                }
                finally
                {
                    Cache.Insert("SqlSource", Source1, SqlDep);
                    CacheMsg.Text = "The data object was created explicitly.";
                }
            }
            else
            {
                CacheMsg.Text = "The data was retrieved from the Cache.";
            }
        }
    }
}