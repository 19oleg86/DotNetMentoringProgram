namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    [Serializable]
    [Table("Order Details")]
    public partial class Order_Detail
    {
        public Order_Detail()
        {

        }
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int ProductID { get; set; }

        [Column(TypeName = "money")]
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public short Quantity { get; set; }
        [DataMember]
        public float Discount { get; set; }
        [DataMember]
        public virtual Order Order { get; set; }
        [DataMember]
        public virtual Product Product { get; set; }
    }
}
