using System.ComponentModel.DataAnnotations;

namespace FilmesSwaggerAPI.Data.Dtos.DtoCinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de Nome é obrigatório")]
        public string Nome { get; set; }
    }
}
