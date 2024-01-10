using FilmesSwaggerAPI.Data.Dtos.DtoEndereco;
using FilmesSwaggerAPI.Data.Dtos.DtoFilme;

namespace FilmesSwaggerAPI.Data.Dtos.DtoSessao
{
    public class ReadSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
    }
}
