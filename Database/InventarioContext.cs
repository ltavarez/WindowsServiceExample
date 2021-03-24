namespace Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InventarioContext : DbContext
    {
        public InventarioContext()
            : base("name=InventarioContext")
        {
        }

        public virtual DbSet<AlertaExistenciaProducto> AlertaExistenciaProducto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.AlertaExistenciaProducto)
                .WithOptional(e => e.Producto)
                .HasForeignKey(e => e.IdProducto);
        }
    }
}
