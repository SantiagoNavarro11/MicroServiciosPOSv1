namespace Core.POS.Servicios
{
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using Core.POS.Interface;
    using Core.POS.Interface.POSConsulta;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Servicio para manejar las operaciones relacionadas con la entidad <see cref="Producto"/>.
    /// </summary>
    public class ProductoServicio : IProductoServicio
    {
        #region Variables

        /// <summary>
        /// Unidad de trabajo que encapsula todos los repositorios del sistema.
        /// </summary>
        private readonly IDLUnidadDeTrabajo _iDLUnidadDeTrabajo;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ProductoServicio"/>.
        /// </summary>
        /// <param name="iDLUnitOfWork">Unidad de trabajo para acceder a los repositorios de datos.</param>
        public ProductoServicio(IDLUnidadDeTrabajo iDLUnitOfWork)
        {
            _iDLUnidadDeTrabajo = iDLUnitOfWork;
        }

        #endregion

        #region Métodos


        /// <summary>
        /// Consulta todos los productos que coincidan con los parámetros de búsqueda proporcionados.
        /// </summary>
        /// <param name="parametrosBusqueda">
        /// Objeto que contiene los filtros para realizar la búsqueda, como nombre o código de barras.
        /// </param>
        /// <returns>
        /// Una colección de objetos <see cref="ProductoDto"/> que cumplen con los criterios especificados.
        /// </returns>
        public async Task<IEnumerable<ProductoDto>> ConsultarProductos(ParametrosProducto parametrosBusqueda)
        {
            return await _iDLUnidadDeTrabajo.DLProducto.ConsultarProductos(parametrosBusqueda);
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="producto">Entidad con los datos del producto a insertar.</param>
        /// <returns>Entidad del producto insertado.</returns>
        public async Task<Producto> InsertarProducto(Producto producto)
        {
            string errores = string.Empty;

            if (producto == null)
                errores += "El producto no puede ser nulo. | ";

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                errores += "El nombre del producto es obligatorio. | ";

            if (string.IsNullOrWhiteSpace(producto.CodigoBarras))
                errores += "El código de barras es obligatorio. | ";

            if (producto.Precio <= 0)
                errores += "El precio debe ser mayor a cero. | ";

            if (producto.FechaRegistro == default)
                producto.FechaRegistro = DateTime.UtcNow;

            // Validar duplicado por código de barras
            if (string.IsNullOrWhiteSpace(errores))
            {
                bool existe = await _iDLUnidadDeTrabajo.DLProducto.ExisteProductoPorCodigoBarras(producto.CodigoBarras);
                if (existe)
                    errores += "Ya existe un producto con ese código de barras. | ";
            }

            if (!string.IsNullOrWhiteSpace(errores))
                throw new ArgumentException(errores.Trim().TrimEnd('|'));

            producto.ProductoId = await _iDLUnidadDeTrabajo.DLProducto.InsertarProducto(new ProductoDto
            {
                CodigoBarras = producto.CodigoBarras,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Costo = producto.Costo,
                Stock = producto.Stock,
                FechaRegistro = producto.FechaRegistro,
                Activo = producto.Activo
            });

            return producto;
        }

        /// <summary>
        /// Actualiza los datos de un producto existente.
        /// </summary>
        /// <param name="producto">Entidad con los datos del producto actualizados.</param>
        /// <returns>Valor booleano que indica si la actualización fue exitosa.</returns>
        public async Task<bool> ActualizarProducto(Producto producto)
        {
            return await _iDLUnidadDeTrabajo.DLProducto.ActualizarProducto(producto.ProductoId, new ProductoDto
            {
                ProductoId = producto.ProductoId,
                CodigoBarras = producto.CodigoBarras,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Costo = producto.Costo,
                Stock = producto.Stock,
                FechaRegistro = producto.FechaRegistro,
                Activo = producto.Activo
            });
        }

        /// <summary>
        /// Elimina un producto por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <returns>Valor booleano que indica si la eliminación fue exitosa.</returns>
        public async Task<bool> EliminarProducto(int id)
        {
            return await _iDLUnidadDeTrabajo.DLProducto.EliminarProducto(id);
        }

        /// <inheritdoc/>
        public async Task<ProductoDto> ConsultarProductoPorId(int id)
        {
            return await _iDLUnidadDeTrabajo.DLProducto.ConsultarProductoPorId(id);
        }

        public Task<bool> ExisteProductoPorCodigoBarras(string codigoBarras)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
