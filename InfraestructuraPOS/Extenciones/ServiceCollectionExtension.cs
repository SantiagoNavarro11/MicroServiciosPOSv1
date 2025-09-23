namespace InfraestructuraPOS.Extenciones
{
    using Core.POS.Interface;
    using CorePOS.Servicios;
    using InfraestructuraPOS.Datos;
    using InfraestructuraPOS.Repositorio.POSConsulta;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Utilitarios.ConfiguracionRepositorio;
    using Utilitarios.Interfaces.ConfiguracionRepositorio;
    using Microsoft.EntityFrameworkCore;

    /// <summary>Extensión para contexto de BD e inyección de dependencias.</summary>
    public static class ServiceCollectionExtension
    {
        #region Métodos

        /// <summary>Extensión para agregar configuración del contexto de base de datos.</summary>
        /// <param name="services">Especifica el contrato para una colección de descriptores de servicio.</param>
        public static void AgregarContextoBD(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración del Contexto.
            services.AddDbContext<POSContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MicroServiciosPOS")));

        }

        /// <summary>Adhiere la inyección de dependencias a las clases.</summary>
        /// <param name="services">Especifica el contrato para una colección de descriptores de servicio.</param>
        public static void InyeccionDependencias(this IServiceCollection services)
        {
            // Repositorio Generico.
            services.AddScoped(typeof(ICrudSqlRepositorio<>), typeof(CrudSqlRepositorio<>));

            // Unidad de trabajo (Unit of Work).|
            services.AddTransient<IServicioUnidadDeTrabajo, ServicioUnidadDeTrabajo>();
            services.AddTransient<IDLUnidadDeTrabajo, DLUnidadDeTrabajo>();

            // Registrar el servicio de ciclo de vida de la app.
            services.AddHostedService<ApplicationLifetimeEventsHostedService>();
        }

        #endregion
    }

}
