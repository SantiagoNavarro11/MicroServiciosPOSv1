namespace InfraestructuraPOS.Repositorio.POSConsulta
{
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using Core.POS.Interface.POSConsulta;
    using InfraestructuraPOS.Datos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Utilitarios.ConfiguracionRepositorio;
    public class DLProducto : CrudSqlRepositorio<Producto>, IDLProducto
    {
        #region Variables
        /// <summary>
        /// Contexto de la base de datos utilizado para acceder a los datos de la tabla Producto.
        /// </summary>
        private readonly POSContext contextDB;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DLPersona"/>.
        /// </summary>
        /// <param name="context">Contexto de base de datos para realizar las consultas.</param>
        public DLProducto(POSContext context) : base(context)
        {
            contextDB = context;
        }

        #endregion

        #region Consulta Personalizada

        /// <summary>
        /// Consulta los productos de la base de datos según los parámetros proporcionados.
        /// </summary>
        public async Task<IEnumerable<ProductoDto>> ConsultarProductos(ParametrosProducto objBusqueda)
        {
            var registro = await contextDB.Producto
                .Where(p =>
                    (string.IsNullOrEmpty(objBusqueda.Nombre) || p.Nombre.Contains(objBusqueda.Nombre)) &&
                    (string.IsNullOrEmpty(objBusqueda.CodigoBarras) || p.CodigoBarras.Contains(objBusqueda.CodigoBarras))
                )
                .Select(p => new ProductoDto
                {
                    ProductoId = p.ProductoId,
                    Nombre = p.Nombre,
                    CodigoBarras = p.CodigoBarras,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    Costo = p.Costo,
                    FechaRegistro = p.FechaRegistro,
                    Activo = p.Activo,
                })
                .AsNoTracking()
                .ToListAsync();

            return registro;
        }

        /// <summary>
        /// Consulta un producto por Id.
        /// </summary>
        public async Task<ProductoDto> ConsultarProductoPorId(int id)
        {
            var producto = await contextDB.Producto
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductoId == id);

            if (producto == null)
                return null;

            return new ProductoDto
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                CodigoBarras = producto.CodigoBarras,
                Precio = producto.Precio,
                Stock = producto.Stock,
                Costo = producto.Costo,
                FechaRegistro = producto.FechaRegistro,
                Activo= producto.Activo
            };
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// </summary>
        public async Task<int> InsertarProducto(ProductoDto productoDto)
        {
            var producto = new Producto
            {
                Nombre = productoDto.Nombre,
                CodigoBarras = productoDto.CodigoBarras,
                Precio = productoDto.Precio,
                Costo = productoDto.Costo,
                Stock = productoDto.Stock,
                FechaRegistro = productoDto.FechaRegistro,
                Activo = productoDto.Activo
            };

            await contextDB.Producto.AddAsync(producto);
            await contextDB.SaveChangesAsync();
            return producto.ProductoId;
        }

        /// <summary>
        /// Actualiza los datos de un producto existente.
        /// </summary>
        public async Task<bool> ActualizarProducto(int id, ProductoDto productoDto)
        {
            var existente = await contextDB.Producto.FindAsync(id);
            if (existente == null)
                return false;

            existente.Nombre = productoDto.Nombre;
            existente.CodigoBarras = productoDto.CodigoBarras;
            existente.Precio = productoDto.Precio;
            existente.Costo = productoDto.Costo;
            existente.Stock = productoDto.Stock;
            existente.FechaRegistro = productoDto.FechaRegistro;
            existente.Activo = productoDto.Activo;

            contextDB.Producto.Update(existente);
            await contextDB.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina un producto por Id.
        /// </summary>
        public async Task<bool> EliminarProducto(int id)
        {
            var producto = await contextDB.Producto.FindAsync(id);
            if (producto == null)
                return false;

            contextDB.Producto.Remove(producto);
            await contextDB.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Verifica si existe un producto con un código de barras.
        /// </summary>
        public async Task<bool> ExisteProductoPorCodigoBarras(string codigoBarras)
        {
            return await contextDB.Producto.AnyAsync(p => p.CodigoBarras == codigoBarras);
        }
        #endregion
    }
}
