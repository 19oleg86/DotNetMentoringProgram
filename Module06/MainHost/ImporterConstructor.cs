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
    [ImportConstructor]
    public class ImporterConstructor
    {
        public ImporterConstructor(ICustomerDAL dal, Logger log)
        {
        }
    }
}
