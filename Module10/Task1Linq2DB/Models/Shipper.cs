using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Linq2DB.Models
{
    [Table(Name ="Shippers")]
    public class Shipper
    {
        [PrimaryKey, Identity]
        [Column(Name ="ShipperID")]
        public int ShipperID { get; set; }
        [Column(Name ="CompanyName")]
        public string CompanyName { get; set; }
    }
}
