using Contracts;
using Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainHost
{
    public class ImporterConstructor
    {
        ICustomerDAL dal;
        Logger logger;
        public ImporterConstructor()
        {
        }
        [ImportingConstructor]
        public ImporterConstructor(ICustomerDAL dal, Logger logger)
        {
            this.dal = dal;
            this.logger = logger;
            Console.WriteLine("Message from Importing Constructor");
        }
    }
}
