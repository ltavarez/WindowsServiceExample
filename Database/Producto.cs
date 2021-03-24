namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            AlertaExistenciaProducto = new HashSet<AlertaExistenciaProducto>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal? Precio { get; set; }

        public int? Cantidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlertaExistenciaProducto> AlertaExistenciaProducto { get; set; }
    }
}
