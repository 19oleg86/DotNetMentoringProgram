using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetTest
{
    public class WorkerOne : IContract
    {
        public void DoSomething()
        {
            Console.WriteLine("WorkerOne's implementation");
        }
    }
}
