using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Linq2DB.Models
{
    [Table(Name ="Suppliers")]
    public class Supplier
    {
        [PrimaryKey, Identity]
        [Column(Name ="SupplierID")]
        public int SupplierID { get; set; }
        [Column(Name ="CompanyName"), NotNull]
        public string CompanyName { get; set; }
    }
}
