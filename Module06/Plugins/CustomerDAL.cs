using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Plugins
{
    [Export(typeof(ICustomerDAL))]
    public class CustomerDAL : ICustomerDAL
    {
        public void ContractMethod()
        {
            Console.WriteLine("Message from CustomerDAL");
        }
    }
}
