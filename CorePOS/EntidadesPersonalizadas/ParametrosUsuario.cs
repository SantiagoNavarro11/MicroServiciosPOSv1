namespace CorePOS.EntidadesPersonalizadas
{
    /// <summary>
    /// Representa un conjunto de parámetros asociados a un usuario.
    /// Se utiliza como filtros de búsqueda dentro del sistema POS.
    /// </summary>
    public class ParametrosUsuario
    {
        #region PametrosDeBusqueda

        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Dirección de correo electrónico del usuario.
        /// Se utiliza como credencial de inicio de sesión y debe ser única.
        /// </summary>
        public string? Correo { get; set; }

        #endregion

    }
}
