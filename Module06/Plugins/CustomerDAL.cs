using System.ComponentModel.Composition;
using Contracts;

namespace Plugins
{
    [Export(typeof(ICustomerDAL))]
    public class CustomerDAL : ICustomerDAL
    {
        
    }
}
