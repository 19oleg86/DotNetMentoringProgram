using Contracts;
using Plugins;
using System.ComponentModel.Composition;

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
