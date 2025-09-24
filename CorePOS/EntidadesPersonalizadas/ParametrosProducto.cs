namespace Core.POS.EntidadesPersonalizadas
{
    /// <summary>
    /// Representa un conjunto de parámetros asociados a un producto.
    /// Se utiliza como filtros de búsqueda dentro del sistema POS.
    /// </summary>
    public class ParametrosProducto
    {
        #region PametrosDeBusqueda
        /// <summary>
        /// Código de barras único que identifica al producto.
        /// </summary>
        public string? CodigoBarras { get; set; }

        /// <summary>
        /// Nombre descriptivo del producto.
        /// </summary>
        public string? Nombre { get; set; }
        #endregion
    }
}
