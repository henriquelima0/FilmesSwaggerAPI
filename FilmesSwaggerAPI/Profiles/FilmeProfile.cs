using AutoMapper;
using FilmesSwaggerAPI.Data.Dtos;
using FilmesSwaggerAPI.Models;

namespace FilmesSwaggerAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>(); 
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}
