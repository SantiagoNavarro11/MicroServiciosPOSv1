namespace InfraestructuraPOS.Datos.Mapeos
{
    using Core.POS.Entidades;
    using CorePOS.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configura la entidad <see cref="Usuario"/> y su correspondencia con la tabla "Usuario" en la base de datos.
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        /// <summary>
        /// Configura las propiedades, restricciones y mapeo de la entidad <see cref="Usuario"/>.
        /// </summary>
        /// <param name="builder">
        /// Objeto <see cref="EntityTypeBuilder{Usuario}"/> que permite definir las reglas de mapeo.
        /// </param>
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            #region Map
            // Nombre de la tabla
            builder.ToTable("Usuario", "Seguridad");

            // Clave primaria
            builder.HasKey(u => u.Id)
                .HasName("PK_Usuario");

            // Propiedades
            builder.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(u => u.Nombre)
                .IsUnique()
                .HasDatabaseName("UQ_Usuario_NombreUsuario");

            builder.Property(u => u.Contrasena)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Correo)
                .HasMaxLength(200);

            builder.Property(u => u.FechaRegistro)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.Estado)
                .IsRequired()
                .HasDefaultValue(true);
            #endregion
        }
    }
}
