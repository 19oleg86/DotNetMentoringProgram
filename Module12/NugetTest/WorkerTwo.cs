﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetTest
{
    class WorkerTwo : IContract
    {
        public void DoSomething()
        {
            Console.WriteLine("WorkerTwo's implementation");
        }
    }
}