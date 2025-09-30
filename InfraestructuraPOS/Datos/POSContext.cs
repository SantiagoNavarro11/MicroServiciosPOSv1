namespace InfraestructuraPOS.Datos
{
    using Core.POS.Entidades;
    using CorePOS.Entidades;
    using InfraestructuraPOS.Datos.Mapeos;
    using Microsoft.EntityFrameworkCore;

    /// <summary>Contexto para el manejo de peticiones de las tablas para la base de datos.</summary>
    public class POSContext : DbContext
    {
        #region Constructor

        /// <summary>Inicializa una nueva instancia de la clase Context.</summary>
        public POSContext()
        {
        }

        /// <summary>Inicializa una nueva instancia de la clase Context.</summary>
        public POSContext(DbContextOptions<POSContext> options)
            : base(options)
        {
        }


        /// <summary>Configuración del Contexto.</summary>
        /// <param name="optionsBuilder">Parámetros de configuración.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        #endregion

        #region Métodos

        /// <summary>Configura el modelo mediante el ModelBuilder.</summary>
        /// <param name="modelBuilder">Objeto ModelBuilder usado para configurar el modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        #endregion

        #region Entidades
        /// <value>Declaración del DbSet Producto.</value>
        public virtual DbSet<Producto> Producto { get; set; }

        /// <value>Declaración del DbSet Usuario.</value>
        public virtual DbSet<Usuario> Usuario { get; set; }

        #endregion
    }
}
