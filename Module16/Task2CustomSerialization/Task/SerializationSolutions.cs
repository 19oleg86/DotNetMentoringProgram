using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.DB;
using Task.TestHelpers;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task
{
    [TestClass]
    public class SerializationSolutions
    {
        Northwind dbContext;

        [TestInitialize]
        public void Initialize()
        {
            dbContext = new Northwind();
        }

        [TestMethod]
        public void RealSerializationCallbacks()
        {
            dbContext.Configuration.ProxyCreationEnabled = false;

            Category tester = new Category();

            Console.WriteLine("\n Before serialization the object contains: ");
            tester.Print();

            Stream stream = File.Open("DataFile.xml", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(stream, tester);

                Console.WriteLine("\n After serialization the object contains: ");
                tester.Print();

                tester = null;
                stream.Close();

                stream = File.Open("DataFile.xml", FileMode.Open);

                tester = (Category)formatter.Deserialize(stream);

                Console.WriteLine("\n After deserialization the object contains: ");
                tester.Print();
                
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Failed to serialize. Reason: " + se.Message);
                throw;
            }
            catch (Exception exc)
            {
                Console.WriteLine("An exception occurred. Reason: " + exc.Message);
                throw;
            }
            finally
            {
                stream.Close();
                stream = null;
                formatter = null;
            }
        }

        [TestMethod]
        public void SerializationCallbacks()
        {
            dbContext.Configuration.ProxyCreationEnabled = false;

            var tester = new XmlDataContractSerializerTester<IEnumerable<Category>>(new NetDataContractSerializer(), true);
            var categories = dbContext.Categories.ToList();

            var t = (dbContext as IObjectContextAdapter).ObjectContext;

            foreach (var category in categories)
            {
                t.LoadProperty(category, x => x.Products);
            }

            dbContext.Categories.Include(x => x.Products).ToList();

            tester.SerializeAndDeserialize(categories);
        }

        [TestMethod]
        public void ISerializable()
        {
            dbContext.Configuration.ProxyCreationEnabled = false;

            string fileName = "dataStuff.xml";

            IFormatter formatter = new BinaryFormatter();

            MethodsOfISerializable.SerializeItem(fileName, formatter);
            MethodsOfISerializable.DeserializeItem(fileName, formatter);
            Console.WriteLine("Done");
            
        }

        [TestMethod]
        public void ISerializationSurrogate()
        {
            dbContext.Configuration.ProxyCreationEnabled = false;

            var tester = new OrderSurrogateMethods();
            var orderDetails = dbContext.Order_Details.ToList();

            dbContext.Order_Details.Include(x => x.Order).ToList();
            dbContext.Order_Details.Include(x => x.Product).ToList();

            var bytes = tester.SerializeData(orderDetails);
            var deserializedData = tester.DeserializeData(bytes);
        }

        [TestMethod]
        public void IDataContractSurrogate()
        {
            dbContext.Configuration.ProxyCreationEnabled = true;
            dbContext.Configuration.LazyLoadingEnabled = true;
            List<Type> knownTypes = new List<Type>();

            knownTypes.Add(typeof(Category));
            knownTypes.Add(typeof(Customer));
            knownTypes.Add(typeof(CustomerDemographic));
            knownTypes.Add(typeof(Employee));
            knownTypes.Add(typeof(Northwind));
            knownTypes.Add(typeof(Order));
            knownTypes.Add(typeof(Order_Detail));
            knownTypes.Add(typeof(Product));
            knownTypes.Add(typeof(Region));
            knownTypes.Add(typeof(Shipper));
            knownTypes.Add(typeof(Supplier));
            knownTypes.Add(typeof(Territory));

            var typeSettings = new DataContractSerializerSettings()
            {
                DataContractResolver = new ProxyDataContractResolver(),
                KnownTypes = knownTypes
            };
            
            var tester = new XmlDataContractSerializerTester<IEnumerable<Order>>(new DataContractSerializer(typeof(IEnumerable<Order>), typeSettings), true);
            var orders = dbContext.Orders.ToList();

            tester.SerializeAndDeserialize(orders);
        }
    }
}
