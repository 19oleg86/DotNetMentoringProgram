using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Task.DB;

namespace Task.TestHelpers
{
    class OrderSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var orderDetail = (Order_Detail)obj;
            info.AddValue("SerializedOrderID", orderDetail.OrderID);
            info.AddValue("SerializedProductID", orderDetail.ProductID);
            info.AddValue("SerializedUnitPrice", orderDetail.UnitPrice);
            info.AddValue("SerializedQuantity", orderDetail.Quantity);
            info.AddValue("SerializedDiscount", orderDetail.Discount);
            info.AddValue("SerializedOrder", orderDetail.Order);
            info.AddValue("SerializedProduct", orderDetail.Product);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var orderDetail = (Order_Detail)obj;

            orderDetail.OrderID = (int)info.GetValue("SerializedOrderID", typeof(int));
            orderDetail.ProductID = (int)info.GetValue("SerializedProductID", typeof(int));
            orderDetail.UnitPrice = (decimal)info.GetValue("SerializedUnitPrice", typeof(decimal));
            orderDetail.Quantity = (short)info.GetValue("SerializedQuantity", typeof(short));
            orderDetail.Discount = (float)info.GetValue("SerializedDiscount", typeof(float));
            orderDetail.Order = (Order)info.GetValue("SerializedOrder", typeof(Order));
            orderDetail.Product = (Product)info.GetValue("SerializedProduct", typeof(Product));

            return orderDetail;
        }
    }
}
