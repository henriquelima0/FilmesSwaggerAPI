using AutoMapper;
using FilmesSwaggerAPI.Data.Dtos.DtoSessao;
using FilmesSwaggerAPI.Models;

namespace FilmesSwaggerAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
    }
}
