namespace Core.POS.EntidadesPersonalizadas
{
    /// <summary>
    /// Representa un conjunto de parámetros asociados a un producto.
    /// Se utiliza como filtros de búsqueda dentro del sistema POS.
    /// </summary>
    public class ParametrosProducto
    {
        /// <summary>
        /// Identificador único del producto en la base de datos.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Código de barras único que identifica al producto.
        /// </summary>
        public string? CodigoBarras { get; set; }

        /// <summary>
        /// Nombre descriptivo del producto.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Precio unitario de venta del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Costo de adquisición del producto.
        /// </summary>
        public decimal? Costo { get; set; }

        /// <summary>
        /// Cantidad disponible en inventario.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Fecha y hora en que se registró el producto en el sistema.
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Indica si el producto está activo dentro del sistema.
        /// </summary>
        public bool Activo { get; set; }
    }
}
