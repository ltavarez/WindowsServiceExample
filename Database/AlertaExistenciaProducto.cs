namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlertaExistenciaProducto")]
    public partial class AlertaExistenciaProducto
    {
        public int Id { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public bool? Activo { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
