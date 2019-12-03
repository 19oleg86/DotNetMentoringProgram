using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Linq2DB.Models
{
    [Table(Name ="Categories")]
    public class Category
    {
        [PrimaryKey, Identity]
        [Column(Name ="CategoryID")]
        public int CategoryID { get; set; }

        [Column(Name ="CategoryName")]
        public string CategoryName { get; set; }
    }
}
