namespace Core.POS.Servicios
{
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using Core.POS.Interface;
    using CorePOS.Entidades;
    using CorePOS.EntidadesPersonalizadas;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Servicio para manejar las operaciones relacionadas con la entidad <see cref="Usuario"/>.
    /// </summary>
    public class UsuarioServicio : IUsuarioServicio
    {
        #region Variables

        /// <summary>
        /// Unidad de trabajo que encapsula todos los repositorios del sistema.
        /// </summary>
        private readonly IDLUnidadDeTrabajo _iDLUnidadDeTrabajo;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UsuarioServicio"/>.
        /// </summary>
        /// <param name="iDLUnitOfWork">Unidad de trabajo para acceder a los repositorios de datos.</param>
        public UsuarioServicio(IDLUnidadDeTrabajo iDLUnitOfWork)
        {
            _iDLUnidadDeTrabajo = iDLUnitOfWork;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Consulta todos los usuarios que coincidan con los parámetros de búsqueda proporcionados.
        /// </summary>
        /// <param name="parametrosBusqueda">Objeto que contiene los filtros para realizar la búsqueda.</param>
        /// <returns>Una colección de objetos <see cref="UsuarioDto"/> que cumplen con los criterios especificados.</returns>
        public async Task<IEnumerable<UsuarioDto>> ConsultarUsuarios(ParametrosUsuario parametrosBusqueda)
        {
            return await _iDLUnidadDeTrabajo.DLUsuario.ConsultarUsuarios(parametrosBusqueda);
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Entidad con los datos del usuario a insertar.</param>
        /// <returns>Entidad del usuario insertado.</returns>
        public async Task<Usuario> InsertarUsuario(Usuario usuario)
        {
            string errores = string.Empty;

            if (usuario == null)
                errores += "El usuario no puede ser nulo. | ";

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                errores += "El nombre de usuario es obligatorio. | ";

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                errores += "La contraseña es obligatoria. | ";

            if (usuario.FechaRegistro == default)
                usuario.FechaRegistro = DateTime.UtcNow;

            //// Validar duplicado por nombre de usuario
            //if (string.IsNullOrWhiteSpace(errores))
            //{
            //    bool existe = await _iDLUnidadDeTrabajo.DLUsuario.(usuario.NombreUsuario);
            //    if (existe)
            //        errores += "Ya existe un usuario con ese nombre de usuario. | ";
            //}

            if (!string.IsNullOrWhiteSpace(errores))
                throw new ArgumentException(errores.Trim().TrimEnd('|'));

            usuario.Id = await _iDLUnidadDeTrabajo.DLUsuario.InsertarUsuario(usuario);

            return usuario;
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        /// <param name="usuario">Entidad con los datos del usuario actualizados.</param>
        /// <returns>Entidad del usuario actualizado.</returns>
        public async Task<UsuarioDto> ActualizarUsuario(UsuarioDto usuario)
        {
            return await _iDLUnidadDeTrabajo.DLUsuario.ActualizarUsuario(usuario.Id, usuario)
                ? usuario
                : throw new Exception("No se pudo actualizar el usuario.");
        }

        /// <summary>
        /// Elimina un usuario por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del usuario.</param>
        /// <returns>Valor booleano que indica si la eliminación fue exitosa.</returns>
        public async Task<bool> EliminarUsuario(int id)
        {
            return await _iDLUnidadDeTrabajo.DLUsuario.EliminarUsuario(id);
        }

        /// <summary>
        /// Valida las credenciales de los usuarios cuando se logueen.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario.</param>
        /// <param name="contrasena}">contraseña del usuario.</param>
        /// <returns>Entidad del usuario con los datos.</returns>
        public async Task<UsuarioDto> ValidarCredenciales(string nombreUsuario, string contrasena)
        {
            return await _iDLUnidadDeTrabajo.DLUsuario.ValidarCredenciales(nombreUsuario, contrasena);
        }

        #endregion
    }
}
