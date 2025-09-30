namespace Core.POS.Interface.POSConsulta
{
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using Core.POS.EntidadesPersonalizadas;
    using CorePOS.Entidades;
    using CorePOS.EntidadesPersonalizadas;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Utilitarios.Interfaces.ConfiguracionRepositorio;

    /// <summary>
    /// Define las operaciones de consulta y manipulación de datos para la entidad <see cref="Usuario"/>.
    /// Esta interfaz expone métodos para realizar operaciones CRUD y validaciones sobre usuarios en el sistema POS.
    /// </summary>
    public interface IDLUsuario : ICrudSqlRepositorio<Usuario>
    {
        #region Consultas

        /// <summary>
        /// Consulta los registros de la entidad <see cref="Usuario"/> según los parámetros de búsqueda.
        /// </summary>
        /// <param name="objBusqueda">Parámetros de búsqueda para filtrar los registros de usuarios.</param>
        /// <returns>
        /// Una colección de objetos <see cref="UsuarioDto"/> que cumplen con los criterios de búsqueda proporcionados.
        /// </returns>
        Task<IEnumerable<UsuarioDto>> ConsultarUsuarios(ParametrosUsuario objBusqueda);

        /// <summary>
        /// Consulta un usuario por su correo electrónico y contraseña para validar credenciales de acceso.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <param name="contrasena">Contraseña del usuario (sin encriptar).</param>
        /// <returns>
        /// Objeto <see cref="UsuarioDto"/> con los datos del usuario si existe, o <c>null</c> si no se encuentra.
        /// </returns>
        Task<UsuarioDto?> ValidarCredenciales(string correo, string contrasena);

        #endregion

        #region Mantenimiento

        /// <summary>
        /// Inserta un nuevo registro de usuario.
        /// </summary>
        /// <param name="usuario">Objeto <see cref="UsuarioDto"/> con la información del usuario a registrar.</param>
        /// <returns>
        /// Identificador único del usuario insertado.
        /// </returns>
        Task<int> InsertarUsuario(Usuario usuario);

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        /// <param name="id">Identificador del usuario a actualizar.</param>
        /// <param name="usuario">Objeto <see cref="UsuarioDto"/> con los nuevos valores del usuario.</param>
        /// <returns>
        /// Valor booleano que indica si la actualización fue exitosa.
        /// </returns>
        Task<bool> ActualizarUsuario(int id, UsuarioDto usuario);

        /// <summary>
        /// Elimina lógicamente un usuario del sistema.
        /// </summary>
        /// <param name="id">Identificador del usuario a eliminar.</param>
        /// <returns>
        /// Valor booleano que indica si la eliminación fue exitosa.
        /// </returns>
        Task<bool> EliminarUsuario(int id);

        #endregion
    }
}
