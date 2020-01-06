﻿using NorthwindLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    public interface ISuppliersCache
    {
        IEnumerable<Supplier> Get(string forUser);
        void Set(string forUser, IEnumerable<Supplier> employees);
    }
}
