using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Task.DB;

namespace Task.TestHelpers
{
    public class MethodsOfISerializable
    {
        public static void SerializeItem(string fileName, IFormatter formatter)
        {
            Northwind dbContext = new Northwind();
            
            var products = dbContext.Products.ToList();
            
            FileStream s = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s, products);
            s.Close();
        }

        public static void DeserializeItem(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            List<Product> product = (List<Product>)formatter.Deserialize(s);
            Console.WriteLine(product);
        }
    }
}
