using Contracts;
using Plugins;

namespace MainHost
{
    [ImportConstructor]
    public class ImporterConstructor
    {
        private readonly ICustomerDAL dal;
        private readonly Logger log;
        public ImporterConstructor(ICustomerDAL dal, Logger log)
        {
            this.dal = dal;
            this.log = log;
        }
    }
}
