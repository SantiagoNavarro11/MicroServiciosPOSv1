namespace InfraestructuraPOS.Extenciones
{
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Threading.Tasks;

    /// <summary> Servicio que maneja eventos del ciclo de vida de la aplicación. </summary>
    public class ApplicationLifetimeEventsHostedService : IHostedService
    {
        #region Campos Privados
        private readonly IHostApplicationLifetime _appLifetime;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ApplicationLifetimeEventsHostedService"/>.
        /// </summary>
        /// <param name="appLifetime">Interfaz para gestionar el ciclo de vida de la aplicación.</param>
        public ApplicationLifetimeEventsHostedService(IHostApplicationLifetime appLifetime)
            => _appLifetime = appLifetime;
        #endregion

        #region Métodos de Ciclo de Vida
        /// <summary>
        /// Método que se ejecuta cuando el servicio se inicia.
        /// </summary>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Registra los eventos del ciclo de vida de la aplicación
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Método que se ejecuta cuando el servicio se detiene.
        /// </summary>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        #endregion

        #region Métodos Privados
        /// <summary>Método que se ejecuta cuando la aplicación se ha iniciado.</summary>
        private void OnStarted()
        {
            Console.WriteLine("MS de POS iniciado", "information_source");
        }

        /// <summary>Método que se ejecuta cuando la aplicación se está deteniendo.</summary>
        private void OnStopping()
        {
            Console.WriteLine("MS de POS se está deteniendo", "warning");
            Thread.Sleep(10000);
        }

        /// <summary>Método que se ejecuta cuando la aplicación se ha detenido.</summary>
        private void OnStopped()
        {
            Console.WriteLine("MS de POS detenida", "warning");
            Thread.Sleep(10000);
        }
        #endregion
    }
}
