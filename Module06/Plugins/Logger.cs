using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    [Export]
    public class Logger
    {
        public void LoggerMethod()
        {
            Console.WriteLine("Message from Logger");
        }
    }
}
