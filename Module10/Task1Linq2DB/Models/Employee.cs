using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Linq2DB.Models
{
    [Table(Name ="Employees")]
    public class Employee
    {
        [PrimaryKey, Identity]
        [Column(Name = "EmployeeID"), NotNull]
        public int EmployeeID { get; set; }
        [Column(Name = "FirstName"), NotNull]
        public string FirstName { get; set; }
        [Column(Name = "LastName"), NotNull]
        public string LastName { get; set; }
        [Column(Name ="Title")]
        public string Title { get; set; }
        [Column(Name ="Region")]
        public string Region { get; set; }
        [Column(Name ="City")]
        public string City { get; set; }

        public List<Region> AllRegions { get; set; }
    }
}
