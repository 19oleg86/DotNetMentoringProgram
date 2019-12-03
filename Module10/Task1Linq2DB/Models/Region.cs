using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Linq2DB.Models
{
    [Table(Name ="Region")]
    public class Region
    {
        [PrimaryKey, Identity]
        [Column(Name ="RegionID")]
        public int RegionID { get; set; }
        [Column(Name = "RegionDescription")]
        public string RegionDescription { get; set; }
    }
}
