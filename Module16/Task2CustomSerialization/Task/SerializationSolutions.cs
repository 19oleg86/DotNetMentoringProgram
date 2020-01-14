using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.DB;
using Task.TestHelpers;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

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

			var tester = new XmlDataContractSerializerTester<IEnumerable<Product>>(new NetDataContractSerializer(), true);
			var products = dbContext.Products.ToList();

			var t = (dbContext as IObjectContextAdapter).ObjectContext;

			foreach (var product in products)
			{
				t.LoadProperty(product, x => x.Order_Details);
			}

			dbContext.Products.Include(x => x.Category).ToList();
			dbContext.Products.Include(x => x.Supplier).ToList();

			tester.SerializeAndDeserialize(products);
		}

		[TestMethod]
		public void ISerializationSurrogate()
		{
			dbContext.Configuration.ProxyCreationEnabled = false;

			var tester = new XmlDataContractSerializerTester<IEnumerable<Order_Detail>>(new NetDataContractSerializer(), true);
			var orderDetails = dbContext.Order_Details.ToList();

			dbContext.Order_Details.Include(x => x.Order).ToList();
			dbContext.Order_Details.Include(x => x.Product).ToList();

			tester.SerializeAndDeserialize(orderDetails);
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

			var tester = new XmlDataContractSerializerTester<IEnumerable<Order>>(new DataContractSerializer(typeof(IEnumerable<Order>), knownTypes), true);
			var orders = dbContext.Orders.ToList();

			tester.SerializeAndDeserialize(orders);
		}
	}
}
