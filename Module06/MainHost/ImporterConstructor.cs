using Contracts;
using Plugins;

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
