using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Linq2DB.Models
{
    [Table(Name= "Products")]
    public class Product
    {
        [PrimaryKey, Identity]
        [Column(Name="ProductID")]
        public int ProductID { get; set; }

        [Column(Name = "ProductName"), NotNull]
        public string ProductName { get; set; }

        [Column(Name = "SupplierID")]
        public int SupplierID { get; set; }

        [Column(Name = "CategoryID")]
        public int CategoryID { get; set; }
    }
}
