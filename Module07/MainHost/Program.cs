using Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MainHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            Newspaper newspaper = new Newspaper();
            Patent patent = new Patent();
            ArrayList catalogObjects = new ArrayList() { book, newspaper, patent };
            DirectoryInfo projectDirectory = new DirectoryInfo(@"..\..");
            var pathToResource = projectDirectory.FullName + @"\Resources\XMLSource.xml";
            
            Console.ReadKey();
        }
    }
}
