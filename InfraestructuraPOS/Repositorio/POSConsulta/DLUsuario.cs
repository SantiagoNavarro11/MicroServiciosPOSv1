namespace InfraestructuraPOS.Repositorio.POSConsulta
{
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using Core.POS.Interface.POSConsulta;
    using CorePOS.Entidades;
    using CorePOS.EntidadesPersonalizadas;
    using InfraestructuraPOS.Datos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Utilitarios.ConfiguracionRepositorio;

    /// <summary>
    /// Repositorio para operaciones CRUD y consultas personalizadas sobre la entidad Usuario.
    /// </summary>
    public class DLUsuario : CrudSqlRepositorio<Usuario>, IDLUsuario
    {
        #region Variables
        /// <summary>
        /// Contexto de la base de datos utilizado para acceder a los datos de la tabla Usuario.
        /// </summary>
        private readonly POSContext contextDB;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DLUsuario"/>.
        /// </summary>
        /// <param name="context">Contexto de base de datos para realizar las consultas.</param>
        public DLUsuario(POSContext context) : base(context)
        {
            contextDB = context;
        }
        #endregion

        #region Consulta Personalizada

        /// <summary>
        /// Consulta los usuarios según parámetros de búsqueda.
        /// </summary>
        public async Task<IEnumerable<UsuarioDto>> ConsultarUsuarios(ParametrosUsuario objBusqueda)
        {
            var registro = await contextDB.Usuario
                .Where(u =>
                    (string.IsNullOrEmpty(objBusqueda.Nombre) || u.Nombre.Contains(objBusqueda.Nombre)) ||
                    (string.IsNullOrEmpty(objBusqueda.Correo) || u.Correo.Contains(objBusqueda.Correo))
                )
                .Select(u => new UsuarioDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    Contrasena = u.Contrasena,
                    Estado = u.Estado,
                    FechaRegistro = u.FechaRegistro
                })
                .AsNoTracking()
                .ToListAsync();

            return registro;
        }

        /// <summary>
        /// Consulta un usuario por Id.
        /// </summary>
        public async Task<UsuarioDto> ConsultarUsuarioPorId(int id)
        {
            var usuario = await contextDB.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Contrasena = usuario.Contrasena,
                Estado = usuario.Estado,
                FechaRegistro = usuario.FechaRegistro
            };
        }

        /// <summary>
        /// Inserta un nuevo usuario.
        /// </summary>
        public async Task<int> InsertarUsuario(Usuario usuarioDto)
        {
            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Correo = usuarioDto.Correo,
                Contrasena = usuarioDto.Contrasena,
                Estado = usuarioDto.Estado,
                FechaRegistro = usuarioDto.FechaRegistro
            };

            await contextDB.Usuario.AddAsync(usuario);
            await contextDB.SaveChangesAsync();
            return usuario.Id;
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        public async Task<bool> ActualizarUsuario(int id, UsuarioDto usuarioDto)
        {
            var existente = await contextDB.Usuario.FindAsync(id);
            if (existente == null)
                return false;

            existente.Nombre = usuarioDto.Nombre;
            existente.Correo = usuarioDto.Correo;
            existente.Contrasena = usuarioDto.Contrasena;
            existente.Estado = usuarioDto.Estado;
            existente.FechaRegistro = usuarioDto.FechaRegistro;

            contextDB.Usuario.Update(existente);
            await contextDB.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina un usuario por Id.
        /// </summary>
        public async Task<bool> EliminarUsuario(int id)
        {
            var usuario = await contextDB.Usuario.FindAsync(id);
            if (usuario == null)
                return false;

            contextDB.Usuario.Remove(usuario);
            await contextDB.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Verifica si existe un usuario por correo.
        /// </summary>
        public async Task<bool> ExisteUsuarioPorCorreo(string correo)
        {
            return await contextDB.Usuario.AnyAsync(u => u.Correo == correo);
        }

        public Task<UsuarioDto?> ValidarCredenciales(string correo, string contrasena)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
