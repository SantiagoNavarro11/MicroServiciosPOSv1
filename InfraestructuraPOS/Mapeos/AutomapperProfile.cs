namespace InfraestructuraPOS.Mapeos
{
    using AutoMapper;
    using Core.POS.Dto;
    using Core.POS.Entidades;
    using CorePOS.Entidades;

    /// <summary>Mapeos entre Entidades <-> Dtos y viceversa.</summary>
    public class AutomapperProfile : Profile
    {
        #region Constructor
        /// <summary>Inicializa una nueva instancia de la clase <see cref="AutomapperProfile"/>.</summary>
        public AutomapperProfile()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
        #endregion
    }
}
