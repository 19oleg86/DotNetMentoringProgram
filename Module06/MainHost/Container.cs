using Contracts;
using Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainHost
{
    public class Container
    {
        //List<T> allTypes = new List<T>();

        public void AddType<T>(T instance) where T : class, ICustomerDAL
        {
            var ins = CreateInstance(instance);
        }

        public T CreateInstance<T>(T arg)
        {
            return new Instance();
        }
    }

    public class Instance
    {
        public Instance()
        {
        }
    }
}
