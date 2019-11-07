using Contracts;
using Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MainHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //ApplicationCatalog catalog = new ApplicationCatalog();
            //CompositionContainer container = new CompositionContainer(catalog);

            //ImporterCustomerBLL importer = new ImporterCustomerBLL();

            //container.ComposeParts(importer);

            //importer.ImporterOfCustomerDAL.ContractMethod();
            //importer.Logger.LoggerMethod();

            var container = new Container();

        }
    }
}
