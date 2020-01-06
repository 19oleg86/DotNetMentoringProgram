using NorthwindLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    internal class SuppliersMemoryCache : ISuppliersCache
    {
        ObjectCache cache = MemoryCache.Default;
        string prefix = "Cache_Suppliers";
        public IEnumerable<Supplier> Get(string forUser)
        {
            return (IEnumerable<Supplier>)cache.Get(prefix + forUser);
        }

        public void Set(string forUser, IEnumerable<Supplier> employees)
        {
            cache.Set(prefix + forUser, employees, ObjectCache.InfiniteAbsoluteExpiration); 
        }
    }
}
