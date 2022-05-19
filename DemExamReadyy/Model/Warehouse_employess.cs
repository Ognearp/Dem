namespace DemExamReadyy.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Warehouse_employess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeesId { get; set; }

        public int? warehouse_Id_warehouse { get; set; }

        public virtual BaseEmployes BaseEmployes { get; set; }

        public virtual warehouse warehouse { get; set; }
    }
}
