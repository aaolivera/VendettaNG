using AutoMapper;
using Dominio.Dto;
using Dominio.Entidades;

namespace Servicios.Conversiones.Impl.Perfiles
{
    public class UsuarioMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "UsuarioMappingProfile"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioDto>();
            Mapper.CreateMap<UsuarioDto, Usuario>();
        }
    }
}