namespace Core.POS.Interface
{
    using Core.POS.Interface.POSConsulta;

    /// <summary>Contrato que provee cada uno de los servicios para ser implementados.</summary>
    public interface IServicioUnidadDeTrabajo
    {
        #region Instancias	

        /// <summary>Inicialización y verificación de la instancia para el servicio .</summary>
        public IProductoServicio ProductoServicio { get; }

        public IUsuarioServicio UsuarioServicio { get; }
        #endregion
    }
}
