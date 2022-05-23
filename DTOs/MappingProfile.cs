using AutoMapper;
using MVC.Models;

namespace MVC.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Pelicula, PeliculaDTO>().ReverseMap();
        }

    }
}
