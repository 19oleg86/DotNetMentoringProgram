using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EntityFramework_Versions
{
    public class EmployeeCreditCardData
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string CardHolderName { get; set; }

        public string LinkToEmployee { get; set; }
    }
}
