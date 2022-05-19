namespace DemExamReadyy.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Delivery")]
    public partial class Delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery()
        {
            Products_to_delivery = new HashSet<Products_to_delivery>();
        }

        [Key]
        public int Id_delivery { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_delivery { get; set; }

        public int EmployeesId { get; set; }

        public int Number_delivry { get; set; }

        public virtual Shop_employe Shop_employe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products_to_delivery> Products_to_delivery { get; set; }
    }
}
