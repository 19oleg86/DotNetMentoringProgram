using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFConsApp
{
    [Export(typeof(ICustomerDAL))]
    class CustomerDAL : ICustomerDAL
    {
    }
}
