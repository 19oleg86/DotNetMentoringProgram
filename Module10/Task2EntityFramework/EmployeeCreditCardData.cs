namespace Task2EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeCreditCardData
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string CardHolderName { get; set; }

        public string LinkToEmployee { get; set; }

    }
}
