using System.ComponentModel.DataAnnotations;

namespace FilmesSwaggerAPI.Data.Dtos.DtoEndereco
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "O campo de logradouro é obrigatório.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo número é obrigatório.")]
        public int Numero { get; set; }
    }
}
