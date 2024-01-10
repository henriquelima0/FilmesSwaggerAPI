using AutoMapper;
using FilmesSwaggerAPI.Data.Dtos.DtoCinema;
using FilmesSwaggerAPI.Models;

namespace FilmesSwaggerAPI.Profiles;

public class CinemaProfile : Profile
{
    public  CinemaProfile() 
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco,
                opt => opt.MapFrom(cinema => cinema.Endereco))
            .ForMember(cinemaDto => cinemaDto.Sessoes,
                opt => opt.MapFrom(cinema => cinema.Sessoes));
        CreateMap<UpdateCinemaDto, Cinema>();
        //mapeamentos mais complexos com os métodos ForMember() e MapFrom().
    }
}
