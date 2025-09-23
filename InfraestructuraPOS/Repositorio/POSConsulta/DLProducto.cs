namespace InfraestructuraPOS.Repositorio.POSConsulta
{
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using Core.POS.Interface.POSConsulta;
    using InfraestructuraPOS.Datos;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Utilitarios.ConfiguracionRepositorio;
    public class DLProducto : CrudSqlRepositorio<Producto>, IDLProducto
    {
        #region Variables
        /// <summary>
        /// Contexto de la base de datos utilizado para acceder a los datos de la tabla Persona.
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

        public Task<bool> ActualizarProducto(int id, ProductoDto producto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoDto> ConsultarProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductoDto>> ConsultarProductos(ParametrosProducto objBusqueda)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarProducto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteProductoPorCodigoBarras(string codigoBarras)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertarProducto(ProductoDto producto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
