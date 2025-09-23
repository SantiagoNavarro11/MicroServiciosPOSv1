namespace Core.POS.Dto
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) que representa un producto.
    /// Se utiliza para exponer la información del producto entre capas de la aplicación
    /// o hacia servicios externos, sin exponer directamente la entidad del dominio.
    /// </summary>
    public class ProductoDto
    {
        /// <summary>
        /// Identificador único del producto.
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
        /// Precio de venta unitario del producto.
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
        /// Fecha de registro del producto en el sistema.
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Indica si el producto está activo dentro del sistema.
        /// </summary>
        public bool Activo { get; set; }
    }
}
