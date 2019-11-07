using Plugins;
using System;
using System.Reflection;

namespace MainHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.ProcessType(typeof(ImporterCustomerBLL));
            container.ProcessType(typeof(Logger));
            container.ProcessType(typeof(CustomerDAL));

            container.AddAssembly(Assembly.GetExecutingAssembly());

            var customerBLL = container.CreateInstance(typeof(ImporterCustomerBLL));
            if (customerBLL != null)
            {
                Console.WriteLine("Instance of ImporterCustomerBLL type is created");
                Console.WriteLine();
            }
        }
    }
}
