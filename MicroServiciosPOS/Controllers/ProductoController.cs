namespace MicroServiciosPOS.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using Core.POS.Interface;

    /// <summary>
    /// Controlador API para gestionar las operaciones relacionadas con los productos del sistema POS.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// Inyección de dependencias de la unidad de trabajo de servicios,
        /// utilizada para acceder a la lógica de negocio relacionada con productos.
        /// </summary>
        private readonly IServicioUnidadDeTrabajo _iServicioUnidadDeTrabajo;

        /// <summary>
        /// Inyección de dependencia de AutoMapper para la conversión entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _iMapper;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProductoController"/>.
        /// </summary>
        /// <param name="iMapper">Instancia de AutoMapper para la conversión de modelos.</param>
        /// <param name="iServiceUnitOfWork">Instancia de la unidad de trabajo de servicios.</param>
        public ProductoController(IMapper iMapper, IServicioUnidadDeTrabajo iServiceUnitOfWork)
        {
            _iMapper = iMapper;
            _iServicioUnidadDeTrabajo = iServiceUnitOfWork;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Consulta la lista de productos registrados según los parámetros de búsqueda especificados.
        /// </summary>
        /// <param name="parametrosBusqueda">
        /// Objeto que contiene los criterios de búsqueda para filtrar los productos (código de barras, nombre, etc.).
        /// </param>
        /// <returns>
        /// Una respuesta HTTP con una lista de objetos <see cref="ProductoDto"/>,
        /// o un código de estado HTTP correspondiente en caso de error.
        /// </returns>
        [HttpGet]
        [Route("ConsultarProductos")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> ConsultarProductos([FromQuery] ParametrosProducto parametrosBusqueda)
        {
            var listaProductos = await _iServicioUnidadDeTrabajo.ProductoServicio.ConsultarProductos(_iMapper.Map<ParametrosProducto>(parametrosBusqueda));

            return Ok(listaProductos?.ToList());
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="productoDto">Objeto con los datos del producto a insertar.</param>
        /// <returns>Respuesta HTTP que indica el resultado de la operación.</returns>
        [HttpPost]
        [Route("InsertarProducto")]
        public async Task<IActionResult> InsertarProducto([FromBody] ProductoDto productoDto)
        {
            try
            {
                var entidad = _iMapper.Map<Producto>(productoDto);

                await _iServicioUnidadDeTrabajo.ProductoServicio.InsertarProducto(entidad);

                return Ok("Producto registrado exitosamente.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                // Error no controlado
                return StatusCode(500, new { mensaje = "Error inesperado al insertar el producto.", detalle = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un producto existente en la base de datos.
        /// </summary>
        /// <param name="productoDto">Objeto con los datos actualizados del producto.</param>
        /// <returns>Respuesta HTTP que indica el resultado de la operación.</returns>
        [HttpPut]
        [Route("ActualizarProducto")]
        public async Task<IActionResult> ActualizarProducto([FromBody] ProductoDto productoDto)
        {
            var entidad = _iMapper.Map<Producto>(productoDto);
            await _iServicioUnidadDeTrabajo.ProductoServicio.ActualizarProducto(entidad);
            return Ok("Producto actualizado correctamente.");
        }

        /// <summary>
        /// Elimina un producto de la base de datos según su identificador.
        /// </summary>
        /// <param name="id">Identificador único del producto a eliminar.</param>
        /// <returns>Respuesta HTTP que indica el resultado de la operación.</returns>
        [HttpDelete]
        [Route("EliminarProducto/{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            await _iServicioUnidadDeTrabajo.ProductoServicio.EliminarProducto(id);
            return Ok("Producto eliminado correctamente.");
        }

        #endregion
    }
}
