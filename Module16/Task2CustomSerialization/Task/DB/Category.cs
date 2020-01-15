namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Serializable()]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
            Description = "Initial Value";
        }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        public void Print()
        {
            Console.WriteLine($"Description : {Description}");
        }

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        { 
            Description += " OnSerializingTrigerred";
            //member2 = "This value went into the data file during serialization.";
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Description += " OnSerializedTrigerred";
            //member2 = "This value was reset after serialization.";
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Description += " OnDeserializingTrigerred";
            //member3 = "This value was set during deserialization";
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Description += " OnDeserializedTrigerred";
            //member4 = "This value was set after deserialization.";
        }
    }
}
