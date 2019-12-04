using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EntityFramework_Versions
{
    public class NorthwindDB : DbContext
    {
        public NorthwindDB() : base("NorthwindDB") { }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }
}
