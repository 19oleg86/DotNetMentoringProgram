using Contracts;
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

            container.AddType(typeof(ICustomerDAL), typeof(CustomerDAL));

            var importProperty = container.CreateInstance(typeof(ImporterCustomerBLL));

            var importConstructor = container.CreateInstance(typeof(ImporterConstructor));

            container.AddAssembly(Assembly.GetAssembly(typeof(CustomerDAL)));

            Console.ReadKey();
        }
    }
}
