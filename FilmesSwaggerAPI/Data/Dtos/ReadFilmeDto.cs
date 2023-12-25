using System.Reflection.Metadata.Ecma335;

namespace FilmesSwaggerAPI.Data.Dtos;

public class ReadFilmeDto
{
    public string Titulo { get; set; }

    public string Genero { get; set; }

    public int Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
