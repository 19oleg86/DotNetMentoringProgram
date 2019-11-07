using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainHost
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ImportConstructor : ImportAttribute
    {

    }
}
