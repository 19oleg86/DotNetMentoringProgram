using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFConsApp
{
    class CustomerBLL
    {
        [Import()]
        public ICustomerDAL CustomerDAL { get; set; }
        [Import()]
        public Logger Logger { get; set; }
    }
}
