namespace Core.POS.Dto
{
    /// <summary>
    /// Objeto de transferencia de datos (DTO) que representa un usuario del sistema.
    /// Se utiliza para exponer la información del usuario entre capas de la aplicación
    /// o hacia servicios externos, sin exponer directamente la entidad de dominio.
    /// </summary>
    public class UsuarioDto
    {
        #region PropiedadesDto

        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Dirección de correo electrónico del usuario.
        /// Se utiliza como credencial de inicio de sesión y debe ser única.
        /// </summary>
        public string? Correo { get; set; }

        /// <summary>
        /// Contraseña de acceso al sistema.
        /// Por seguridad, se recomienda almacenar este valor encriptado.
        /// </summary>
        public string? Contrasena { get; set; }

        /// <summary>
        /// Fecha y hora en que el usuario fue registrado en el sistema.
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Estado del usuario dentro del sistema.
        /// True indica que el usuario está activo, False que está inactivo.
        /// </summary>
        public bool Estado { get; set; }

        #endregion
    }
}
