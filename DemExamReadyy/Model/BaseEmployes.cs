namespace DemExamReadyy.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BaseEmployes
    {
        [Key]
        public int EmployeesId { get; set; }

        [Required]
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public int? id_role { get; set; }

        public virtual Admins Admins { get; set; }

        public virtual Role_employess Role_employess { get; set; }

        public virtual Shop_employe Shop_employe { get; set; }

        public virtual Warehouse_employess Warehouse_employess { get; set; }
    }
}
