using AutoMapper;
using LavacarAPI.DTOs;
using LavacarAPI.Models;

namespace LavacarAPI.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapea Usuario → UsuarioDto
            CreateMap<NivelCliente, NivelClienteDTO>().ReverseMap();
        }
    }
}
