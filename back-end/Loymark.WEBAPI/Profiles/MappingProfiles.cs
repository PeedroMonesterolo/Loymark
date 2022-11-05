using AutoMapper;
using Loymark.Core.Entities;
using Loymark.WEBAPI.Dtos;

namespace Loymark.WEBAPI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Usuario, AddUsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Actividad, ActividadDto>()
                .ForMember(dest => dest.Usuario, origen => origen.MapFrom(origen => $"{origen.Usuario.Apellido}, {origen.Usuario.Nombre}"))
                .ReverseMap()
                .ForMember(origen => origen.Usuario, dest => dest.Ignore());
        }
    }
}
