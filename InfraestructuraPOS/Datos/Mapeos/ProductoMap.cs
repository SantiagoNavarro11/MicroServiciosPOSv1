namespace InfraestructuraPOS.Datos.Mapeos
{
    using Core.POS.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configura la entidad <see cref="Producto"/> y su correspondencia con la tabla "Productos" en la base de datos.
    /// </summary>
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        /// <summary>
        /// Configura las propiedades, restricciones y mapeo de la entidad <see cref="Producto"/>.
        /// </summary>
        /// <param name="builder">
        /// Objeto <see cref="EntityTypeBuilder{Producto}"/> que permite definir las reglas de mapeo.
        /// </param>
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            #region Map
            // Nombre de la tabla
            builder.ToTable("Producto", "Inventario");

            // Clave primaria
            builder.HasKey(p => p.ProductoId)
                .HasName("PK_Productos");

            // Propiedades
            builder.Property(p => p.CodigoBarras)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.CodigoBarras)
                .IsUnique()
                .HasDatabaseName("UQ_Productos_CodigoBarras");

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Precio)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Costo)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Stock)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.FechaRegistro)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.Activo)
                .IsRequired()
                .HasDefaultValue(true);
            #endregion
        }
    }
}
