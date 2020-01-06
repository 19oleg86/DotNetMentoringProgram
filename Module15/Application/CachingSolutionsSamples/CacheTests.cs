using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindLibrary;
using System.Linq;
using System.Threading;

namespace CachingSolutionsSamples
{
	[TestClass]
	public class CacheTests
	{
		[TestMethod]
		public void MemoryCacheCategory()
		{
			var categoryManager = new CategoriesManager(new CategoriesMemoryCache());

			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine(categoryManager.GetCategories().Count());
				Thread.Sleep(100);
			}
		}

		//[TestMethod]
		//public void RedisCache()
		//{
		//	var categoryManager = new CategoriesManager(new CategoriesRedisCache("localhost"));

		//	for (var i = 0; i < 10; i++)
		//	{
		//		Console.WriteLine(categoryManager.GetCategories().Count());
		//		Thread.Sleep(100);
		//	}
		//}

		[TestMethod]
		public void MemoryCacheEmployee()
		{
			var employeeManager = new EmployeesManager(new EmployeesMemoryCache());

			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine(employeeManager.GetEmployees().Count());
				Thread.Sleep(100);
			}
		}

		[TestMethod]
		public void MemoryCacheSupplier()
		{
			var supplierManager = new SuppliersManager(new SuppliersMemoryCache());

			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine(supplierManager.GetSuppliers().Count());
				Thread.Sleep(100);
			}
		}
	}
}
