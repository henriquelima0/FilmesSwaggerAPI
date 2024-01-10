using FilmesSwaggerAPI.Data.Dtos.DtoEndereco;
using FilmesSwaggerAPI.Data.Dtos.DtoSessao;

namespace FilmesSwaggerAPI.Data.Dtos.DtoCinema
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
