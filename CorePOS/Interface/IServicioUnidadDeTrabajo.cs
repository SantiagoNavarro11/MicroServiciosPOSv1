using Core.POS.Interface.POSConsulta;

namespace Core.POS.Interface
/// <summary>Contrato que provee cada uno de los servicios para ser implementados.</summary>
{
    public interface IServicioUnidadDeTrabajo
    {
        #region Instancias	

        /// <summary>Inicialización y verificación de la instancia para el servicio .</summary>
        public IProductoServicio ProductoServicio { get; }
        #endregion
    }
}
