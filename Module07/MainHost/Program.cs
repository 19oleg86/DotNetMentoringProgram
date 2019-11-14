using Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlReaderWriter;

namespace MainHost
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo projectDirectory = new DirectoryInfo(@"..\..");
            var pathToResource = projectDirectory.FullName + @"\Resources\XMLSource.xml";

            ReaderFromXml xmlReader = new ReaderFromXml();

            ArrayList finalResult = xmlReader.ReadFromXml(pathToResource);
            
            Console.ReadKey();
        }
    }
}
