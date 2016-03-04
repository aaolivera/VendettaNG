using AutoMapper;
using Dominio.Dto;
using Dominio.Entidades;

namespace Servicios.Conversiones.Impl.Perfiles
{
    public class EdificioMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "EdificioMappingProfile"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Edificio, EdificioDto>();
            Mapper.CreateMap<EdificioDto, Edificio>();
        }
    }
}