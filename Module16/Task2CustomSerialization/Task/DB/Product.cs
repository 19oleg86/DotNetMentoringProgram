namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Serializable]
    public partial class Product : ISerializable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_Details = new HashSet<Order_Detail>();
        }

        public Product(SerializationInfo info, StreamingContext context)
        {
            ProductID = (int)info.GetValue("SerializedProductId", typeof(int));
            ProductName = (string)info.GetValue("SerializedProductName", typeof(string));
            SupplierID = (int?)info.GetValue("SerializedSupplierID", typeof(int?));
            CategoryID = (int?)info.GetValue("SerializedCategoryID", typeof(int?));
            QuantityPerUnit = (string)info.GetValue("SerializedQuantityPerUnit", typeof(string));
            UnitPrice = (decimal?)info.GetValue("SerializedUnitPrice", typeof(decimal?));
            UnitsInStock = (short?)info.GetValue("SerializedUnitsInStock", typeof(short?));
            UnitsOnOrder = (short?)info.GetValue("SerializedUnitsOnOrder", typeof(short?));
            ReorderLevel = (short?)info.GetValue("SerializedReorderLevel", typeof(short?));
        }
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Details { get; set; }

        public virtual Supplier Supplier { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SerializedProductId", ProductID, typeof(int));
            info.AddValue("SerializedProductName", ProductName, typeof(string));
            info.AddValue("SerializedSupplierID", SupplierID, typeof(int?));
            info.AddValue("SerializedCategoryID", CategoryID, typeof(int?));
            info.AddValue("SerializedQuantityPerUnit", QuantityPerUnit, typeof(string));
            info.AddValue("SerializedUnitPrice", UnitPrice, typeof(decimal?));
            info.AddValue("SerializedUnitsInStock", UnitsInStock, typeof(short?));
            info.AddValue("SerializedUnitsOnOrder", UnitsOnOrder, typeof(short?));
            info.AddValue("SerializedReorderLevel", ReorderLevel, typeof(short?));
        }
    }
}
