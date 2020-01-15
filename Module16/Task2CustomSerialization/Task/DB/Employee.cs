namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Employees1 = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            Territories = new HashSet<Territory>();
        }

        [DataMember]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        [DataMember]
        public string FirstName { get; set; }

        [StringLength(30)]
        [DataMember]
        public string Title { get; set; }

        [StringLength(25)]
        [DataMember]
        public string TitleOfCourtesy { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public DateTime? HireDate { get; set; }

        [StringLength(60)]
        [DataMember]
        public string Address { get; set; }

        [StringLength(15)]
        [DataMember]
        public string City { get; set; }

        [StringLength(15)]
        [DataMember]
        public string Region { get; set; }

        [StringLength(10)]
        [DataMember]
        public string PostalCode { get; set; }

        [StringLength(15)]
        [DataMember]
        public string Country { get; set; }

        [StringLength(24)]
        [DataMember]
        public string HomePhone { get; set; }

        [StringLength(4)]
        [DataMember]
        public string Extension { get; set; }

        [Column(TypeName = "image")]
        [DataMember]
        public byte[] Photo { get; set; }

        [Column(TypeName = "ntext")]
        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public int? ReportsTo { get; set; }

        [StringLength(255)]
        [DataMember]
        public string PhotoPath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Employee> Employees1 { get; set; }

        [DataMember]
        public virtual Employee Employee1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
