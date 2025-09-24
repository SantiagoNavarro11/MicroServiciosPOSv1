namespace CorePOS.Servicios
{
    using Core.POS.Interface.POSConsulta;
    using Core.POS.Servicios;
    using AutoMapper;
    using Core.POS.Interface;

    /// <summary>
    /// Implementación de la unidad de trabajo para los servicios del sistema de productos.
    /// Se encarga de inicializar y proporcionar acceso centralizado a los diferentes servicios del sistema.
    /// </summary>
    public partial class ServicioUnidadDeTrabajo : IServicioUnidadDeTrabajo
    {
        #region Variables

        /// <summary>
        /// Instancia de la unidad de trabajo de datos (Data Layer) que encapsula los repositorios de acceso a base de datos.
        /// </summary>
        private readonly IDLUnidadDeTrabajo _iDLUnidadDeTrabajo;

        /// <summary>
        /// Instancia del mapeador de objetos (AutoMapper) para la conversión de modelos entre diferentes capas.
        /// </summary>
        private readonly IMapper _iMapper;

        /// <summary>
        /// Instancia del servicio que gestiona la lógica de negocio relacionada con los Productos del sistema.
        /// Su inicialización es controlada para garantizar una única instancia durante el ciclo de vida.
        /// </summary>
        private readonly IProductoServicio _iProductoServicio;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ServiceUnitOfWork"/>.
        /// </summary>
        /// <param name="iDLUnitOfWork">
        /// Instancia inyectada de <see cref="IDLUnitOfWork"/>, que gestiona el acceso a los repositorios de datos.
        /// </param>
        /// <param name="iMapper">
        /// Instancia inyectada de <see cref="IMapper"/> para realizar el mapeo de entidades y modelos DTO.
        /// </param>
        public ServicioUnidadDeTrabajo(IDLUnidadDeTrabajo iDLUnitOfWork, IMapper iMapper)
        {
            _iDLUnidadDeTrabajo = iDLUnitOfWork;
            _iMapper = iMapper;
        }

        #endregion

        #region Instancias

        /// <summary>
        /// Obtiene una instancia del servicio <see cref="_iProductoServicio"/>.
        /// Si no existe una instancia previa, se crea una nueva utilizando la unidad de trabajo de datos actual.
        /// </summary>
        public IProductoServicio ProductoServicio => _iProductoServicio ?? new ProductoServicio(_iDLUnidadDeTrabajo);

        #endregion
    }
}
