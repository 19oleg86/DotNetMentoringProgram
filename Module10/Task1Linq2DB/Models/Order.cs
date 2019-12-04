using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace Task1Linq2DB.Models
{
    [Table(Name ="Orders")]
    public class Order
    {
        [PrimaryKey, Identity]
        [Column(Name ="OrderID")]
        public int OrderID { get; set; }

        [Column(Name ="CustomerID")]
        public string CustomerID { get; set; }

        [Column(Name ="EmployeeID")]
        public int EmployeeID { get; set; }

        [Column(Name = "ShippedDate")]
        public DateTime ShippedDate { get; set; }

        [Column(Name ="ShipName")]
        public string ShipName { get; set; }

        [Column(Name ="ShipCountry")]
        public string ShipCountry { get; set; }
        [Column(Name ="ShipVia")]
        public int ShipVia { get; set; }

    }
}
