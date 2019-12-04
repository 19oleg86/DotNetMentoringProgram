using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Linq2DB.Models
{
    [Table(Name ="Order Details")]
    public class OrderDetails
    {
        [PrimaryKey, Identity]
        [Column(Name ="OrderID")]
        public int OrderID { get; set; }
        [Column(Name ="ProductID")]
        public int ProductID { get; set; }
        [Column(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
