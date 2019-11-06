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
    public class ImporterCustomerBLL
    {
        [Import(typeof(ICustomerDAL))]
        public ICustomerDAL ImporterOfCustomerDAL { get; set; }

        [Import(typeof(Logger))]
        public Logger Logger { get; set; }
    }
}
