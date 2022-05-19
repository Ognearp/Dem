namespace DemExamReadyy.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shop")]
    public partial class Shop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shop()
        {
            Prodoct_in_shop = new HashSet<Prodoct_in_shop>();
            Shop_employe = new HashSet<Shop_employe>();
        }

        [Key]
        public int Id_shop { get; set; }

        [Required]
        [StringLength(50)]
        public string adress { get; set; }

        [Required]
        [StringLength(50)]
        public string fio_employee { get; set; }

        [Required]
        [StringLength(50)]
        public string number_phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodoct_in_shop> Prodoct_in_shop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop_employe> Shop_employe { get; set; }
    }
}
