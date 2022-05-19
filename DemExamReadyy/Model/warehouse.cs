namespace DemExamReadyy.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("warehouse")]
    public partial class warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public warehouse()
        {
            Product_in_warehouse = new HashSet<Product_in_warehouse>();
            Warehouse_employess = new HashSet<Warehouse_employess>();
        }

        [Key]
        public int Id_warehouse { get; set; }

        [StringLength(50)]
        public string name_warehouse { get; set; }

        public int id_employee_warehouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_in_warehouse> Product_in_warehouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse_employess> Warehouse_employess { get; set; }
    }
}
