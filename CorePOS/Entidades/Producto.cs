namespace Core.POS.Entidades
{
    using Utilitarios.Entidades;

    /// <summary>
    /// Representa un producto dentro del sistema POS.
    /// Contiene información de identificación, código de barras, precios, inventario y estado.
    /// </summary>
    public class Producto : EntidadBase
    {
        #region Propiedades
        /// <summary>
        /// Identificador único del producto en la base de datos.
        /// Corresponde a la columna ProductoId (Primary Key, Identity).
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Código de barras único que identifica al producto.
        /// Corresponde a la columna CodigoBarras (NVARCHAR(50), NOT NULL, UNIQUE).
        /// </summary>
        public string? CodigoBarras { get; set; }

        /// <summary>
        /// Nombre descriptivo del producto.
        /// Corresponde a la columna Nombre (NVARCHAR(150), NOT NULL).
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Precio de venta unitario del producto.
        /// Corresponde a la columna Precio (DECIMAL(18,2), NOT NULL).
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Costo de adquisición del producto.
        /// Corresponde a la columna Costo (DECIMAL(18,2), NULL).
        /// </summary>
        public decimal? Costo { get; set; }

        /// <summary>
        /// Cantidad disponible en inventario.
        /// Corresponde a la columna Stock (INT, NOT NULL, DEFAULT 0).
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Fecha y hora en que se registró el producto en el sistema.
        /// Corresponde a la columna FechaRegistro (DATETIME, NOT NULL, DEFAULT GETDATE()).
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Indica si el producto está activo o no dentro del sistema.
        /// Corresponde a la columna Activo (BIT, NOT NULL, DEFAULT 1).
        /// </summary>
        public bool Activo { get; set; }
        #endregion
    }
}
