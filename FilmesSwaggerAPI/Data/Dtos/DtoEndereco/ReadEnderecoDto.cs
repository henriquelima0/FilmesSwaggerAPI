using System.ComponentModel.DataAnnotations;

namespace FilmesSwaggerAPI.Data.Dtos.DtoEndereco
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
