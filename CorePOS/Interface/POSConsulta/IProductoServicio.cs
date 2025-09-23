namespace Core.POS.Interface.POSConsulta
{
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Define las operaciones de negocio relacionadas con la gestión de productos en el sistema POS.
    /// </summary>
    public interface IProductoServicio
    {
        #region Instancias

        /// <summary>
        /// Consulta los registros de la entidad <see cref="Producto"/> según los parámetros de búsqueda.
        /// </summary>
        /// <param name="parametrosBusqueda">Parámetros de entrada para la consulta de productos.</param>
        /// <returns>
        /// Una lista de objetos <see cref="ProductoDto"/> que cumplen con los criterios de búsqueda.
        /// </returns>
        Task<IEnumerable<ProductoDto>> ConsultarProductos(ParametrosProducto parametrosBusqueda);

        /// <summary>
        /// Inserta un nuevo registro de producto.
        /// </summary>
        /// <param name="producto">Entidad <see cref="Producto"/> a insertar.</param>
        /// <returns>Entidad insertada con su identificador asignado.</returns>
        Task<Producto> InsertarProducto(Producto producto);

        /// <summary>
        /// Actualiza un registro existente de producto.
        /// </summary>
        /// <param name="producto">Entidad <see cref="Producto"/> con los datos actualizados.</param>
        /// <returns>Valor booleano que indica si la actualización fue exitosa.</returns>
        Task<bool> ActualizarProducto(Producto producto);

        /// <summary>
        /// Elimina un registro de producto según su identificador.
        /// </summary>
        /// <param name="id">Identificador único del producto a eliminar.</param>
        /// <returns>Valor booleano que indica si la eliminación fue exitosa.</returns>
        Task<bool> EliminarProducto(int id);

        /// <summary>
        /// Consulta un producto específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del producto a consultar.</param>
        /// <returns>Objeto <see cref="ProductoDto"/> correspondiente al registro solicitado.</returns>
        Task<ProductoDto> ConsultarProductoPorId(int id);

        /// <summary>
        /// Verifica si existe un producto en el sistema por su código de barras.
        /// </summary>
        /// <param name="codigoBarras">Código de barras del producto a validar.</param>
        /// <returns>Valor booleano que indica si el producto ya existe en el sistema.</returns>
        Task<bool> ExisteProductoPorCodigoBarras(string codigoBarras);

        #endregion
    }
}
