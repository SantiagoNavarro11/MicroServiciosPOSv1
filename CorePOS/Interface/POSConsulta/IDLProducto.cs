namespace Core.POS.Interface.POSConsulta
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using Utilitarios.Interfaces.ConfiguracionRepositorio;

    /// <summary>
    /// Define las operaciones de consulta y manipulación de datos para la entidad <see cref="Producto"/>.
    /// Esta interfaz expone métodos para realizar operaciones CRUD y validaciones sobre productos en el sistema POS.
    /// </summary>
    public interface IDLProducto : ICrudSqlRepositorio<Producto>
    {
        #region Consultas

        /// <summary>
        /// Consulta los registros de la entidad <see cref="Producto"/> según los parámetros de búsqueda.
        /// </summary>
        /// <param name="objBusqueda">Parámetros de búsqueda para filtrar los registros de productos.</param>
        /// <returns>
        /// Una colección de objetos <see cref="ProductoDto"/> que cumplen con los criterios de búsqueda proporcionados.
        /// </returns>
        Task<IEnumerable<ProductoDto>> ConsultarProductos(ParametrosProducto objBusqueda);

        /// <summary>
        /// Consulta un producto específico por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del producto.</param>
        /// <returns>
        /// Objeto <see cref="ProductoDto"/> correspondiente al registro solicitado.
        /// </returns>
        Task<ProductoDto> ConsultarProductoPorId(int id);

        /// <summary>
        /// Verifica si existe un producto con el código de barras proporcionado.
        /// </summary>
        /// <param name="codigoBarras">Código de barras del producto a validar.</param>
        /// <returns>
        /// Valor booleano que indica si el producto existe en el sistema.
        /// </returns>
        Task<bool> ExisteProductoPorCodigoBarras(string codigoBarras);

        #endregion

        #region Mantenimiento

        /// <summary>
        /// Inserta un nuevo registro de producto.
        /// </summary>
        /// <param name="producto">Objeto <see cref="ProductoDto"/> con la información del producto a registrar.</param>
        /// <returns>
        /// Identificador único del producto insertado.
        /// </returns>
        Task<int> InsertarProducto(ProductoDto producto);

        /// <summary>
        /// Actualiza los datos de un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto a actualizar.</param>
        /// <param name="producto">Objeto <see cref="ProductoDto"/> con los nuevos valores del producto.</param>
        /// <returns>
        /// Valor booleano que indica si la actualización fue exitosa.
        /// </returns>
        Task<bool> ActualizarProducto(int id, ProductoDto producto);

        /// <summary>
        /// Elimina lógicamente un producto del sistema.
        /// </summary>
        /// <param name="id">Identificador del producto a eliminar.</param>
        /// <returns>
        /// Valor booleano que indica si la eliminación fue exitosa.
        /// </returns>
        Task<bool> EliminarProducto(int id);

        #endregion
    }
}
