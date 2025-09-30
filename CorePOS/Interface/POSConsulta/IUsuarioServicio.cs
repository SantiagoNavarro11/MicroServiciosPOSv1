namespace Core.POS.Interface
{
    using Core.POS.Dto;
    using CorePOS.Entidades;
    using CorePOS.EntidadesPersonalizadas;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Define las operaciones de negocio relacionadas con la gestión de usuarios en el sistema POS.
    /// </summary>
    public interface IUsuarioServicio
    {
        /// <summary>
        /// Consulta los usuarios según los parámetros de búsqueda especificados.
        /// </summary>
        /// <param name="parametrosBusqueda">Criterios de búsqueda como nombre, rol o estado.</param>
        /// <returns>Una colección de <see cref="UsuarioDto"/> que cumplen con los criterios.</returns>
        Task<IEnumerable<UsuarioDto>> ConsultarUsuarios(ParametrosUsuario parametrosBusqueda);

        /// <summary>
        /// Inserta un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuario">Objeto <see cref="UsuarioDto"/> con la información del usuario a registrar.</param>
        /// <returns>El usuario insertado con su identificador asignado.</returns>
        Task<Usuario> InsertarUsuario(Usuario usuario);

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="usuario">Objeto <see cref="UsuarioDto"/> con los datos actualizados.</param>
        /// <returns>El usuario actualizado.</returns>
        Task<UsuarioDto> ActualizarUsuario(UsuarioDto usuario);

        /// <summary>
        /// Elimina un usuario según su identificador único.
        /// </summary>
        /// <param name="id">Identificador del usuario a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa; de lo contrario, false.</returns>
        Task<bool> EliminarUsuario(int id);        

        /// <summary>
        /// Valida las credenciales de acceso de un usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <param name="contrasena">Contraseña en texto plano o hash según la implementación.</param>
        /// <returns>El usuario autenticado como <see cref="UsuarioDto"/> si las credenciales son correctas; de lo contrario, null.</returns>
        Task<UsuarioDto> ValidarCredenciales(string nombreUsuario, string contrasena);
    }
}
