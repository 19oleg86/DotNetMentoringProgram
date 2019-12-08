using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2EntityFramework_Versions
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitializeDB()
        {
            using (var db = new NorthwindDB())
            {
                db.Database.Initialize(true);
                db.Database.CreateIfNotExists();
                
            }
        }
    }
}
