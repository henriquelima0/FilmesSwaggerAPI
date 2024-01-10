using System.ComponentModel.DataAnnotations;

namespace FilmesSwaggerAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de logradouro é obrigatório.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo número é obrigatório.")]
        public int Numero { get; set; }

        // Relação 1:1 com o Endereço
        // Sem endereço não existe Cinema, por isso, não é necessário chamar o ID do cinema neste caso; somente na model Endereco
        public virtual Cinema Cinema { get; set; }
    }
}
