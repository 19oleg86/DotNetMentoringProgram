using System.Collections.Generic;

namespace NorthwindDAL
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public List<Product> Products { get; set; }
    }
}