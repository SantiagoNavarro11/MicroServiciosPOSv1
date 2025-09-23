namespace InfraestructuraPOS.Extenciones
{
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Threading.Tasks;

    /// <summary> Servicio que maneja eventos del ciclo de vida de la aplicación. </summary>
    public class ApplicationLifetimeEventsHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;

        /// <summary>Inicializa una nueva instancia de la clase <see cref="ApplicationLifetimeEventsHostedService"/>.</summary>
        /// <param name="appLifetime">Interfaz para gestionar el ciclo de vida de la aplicación.</param>
        public ApplicationLifetimeEventsHostedService(IHostApplicationLifetime appLifetime) => _appLifetime = appLifetime;

        /// <summary>Método que se ejecuta cuando el servicio se inicia.</summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Tarea completada.</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {

            // Registra el método OnStarted para ejecutarse cuando la aplicación se inicia.
            _appLifetime.ApplicationStarted.Register(OnStarted);

            // Registra el método OnStopping para ejecutarse cuando la aplicación se está deteniendo.
            _appLifetime.ApplicationStopping.Register(OnStopping);

            // Registra el método OnStopped para ejecutarse cuando la aplicación se ha detenido.
            _appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;

        }

        /// <summary>Método que se ejecuta cuando la aplicación se ha iniciado.</summary>
        private void OnStarted()
        {
            Console.WriteLine("MS de POS iniciado", "information_source");
        }

        /// <summary>Método que se ejecuta cuando la aplicación se está deteniendo.</summary>
        private void OnStopping()
        {
            Console.WriteLine("Ms de POS se está deteniendo", "warning");
            Thread.Sleep(10000);
        }

        /// <summary>Método que se ejecuta cuando la aplicación se ha detenido.</summary>
        private void OnStopped()
        {
            Console.WriteLine("Ms de POS detenida", "warning");
            Thread.Sleep(10000);
        }

        /// <summary>Método que se ejecuta cuando el servicio se detiene.</summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Una tarea completada.</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    
    }
}
