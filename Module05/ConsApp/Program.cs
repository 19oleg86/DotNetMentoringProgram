using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl + C for exit");
            while (true)
            {
                var k = Console.ReadKey(true);
                if ((k.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    if ((k.Key & ConsoleKey.C) != 0)
                    {
                        break;
                    }
                }

                string[] pathesToWatch = Environment.GetCommandLineArgs();
                
                using (FileSystemWatcher watcher = new FileSystemWatcher())
                {

                }
            } 
        }
    }
}
