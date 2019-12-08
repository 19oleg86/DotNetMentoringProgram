using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2EntityFramework_Versions.Migrations;

namespace Task2EntityFramework_Versions
{
    public class SampleInitializer : DropCreateDatabaseIfModelChanges<NorthwindDB>
    {
        protected override void Seed(NorthwindDB context)
        {
            List<Category> categories = new List<Category>
            {
                new Category { CategoryID = 1, CategoryName = "Category Name1" },
                new Category { CategoryID = 2, CategoryName = "Category Name2" },
                new Category { CategoryID = 3, CategoryName = "Category Name3" },
                new Category { CategoryID = 4, CategoryName = "Category Name4" }
            };

            foreach (Category category in categories)
                context.Categories.Add(category);

            context.SaveChanges();
            base.Seed(context);
        }
    }

    public class NorthwindDB : DbContext
    {
        public NorthwindDB() : base("NorthwindDB") 
        {
            Database.SetInitializer<NorthwindDB>(new SampleInitializer());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<EmployeeCreditCardData> EmployeeCreditCardInfo { get; set; }

        public DbSet<Regions> AllRegions { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
