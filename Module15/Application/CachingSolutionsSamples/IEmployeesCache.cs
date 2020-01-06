using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
    public interface IEmployeesCache
    {
        IEnumerable<Employee> Get(string forUser);
        void Set(string forUser, IEnumerable<Employee> employees);
    }
}
