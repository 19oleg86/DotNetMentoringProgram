namespace Task2EntityFramework_Versions.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Task2EntityFramework_Versions.NorthwindDB>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Task2EntityFramework_Versions.NorthwindDB context)
        {
            //context.Categories.AddOrUpdate(
            //        h => h.CategoryName,
            //        new Category
            //        {
            //            CategoryID = 1,
            //            CategoryName = "Name of Category"
            //        });
            //context.AllRegions.AddOrUpdate(
            //    h => h.RegionDescription,
            //    new Regions
            //    {
            //        Id = 1,
            //        RegionDescription = "Description of Region"
            //    });
            //context.Products.AddOrUpdate(
            //    h => h.ProductName,
            //    new Product
            //    {
            //        ProductID = 1,
            //        ProductName = "Name of Product",
            //        CategoryID = 2,
            //        SupplierID = 3
            //    });
            //context.SaveChanges();
        }
    }
}
