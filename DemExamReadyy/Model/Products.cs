namespace DemExamReadyy.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products : Base
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            Prodoct_in_shop = new HashSet<Prodoct_in_shop>();
            Product_in_warehouse = new HashSet<Product_in_warehouse>();
            Products_to_delivery = new HashSet<Products_to_delivery>();
        }

        [Key]
        public int Id_product { get; set; }

        [StringLength(50)]
        public string name_product { get; set; }

        [StringLength(50)]
        public string type_product { get; set; }

        public double? cost { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        [StringLength(50)]
        public string unit_of { get; set; }

        [Column(TypeName = "image")]
        public byte[] photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodoct_in_shop> Prodoct_in_shop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_in_warehouse> Product_in_warehouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products_to_delivery> Products_to_delivery { get; set; }
    }
}
