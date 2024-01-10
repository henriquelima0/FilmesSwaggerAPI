using AutoMapper;
using FilmesSwaggerAPI.Data.Dtos.DtoCinema;
using FilmesSwaggerAPI.Data.Dtos.DtoEndereco;
using FilmesSwaggerAPI.Models;

namespace FilmesSwaggerAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
