using FilmesSwaggerAPI.Data.Dtos.DtoCinema;
using FilmesSwaggerAPI.Data.Dtos.DtoSessao;
using System.Reflection.Metadata.Ecma335;

namespace FilmesSwaggerAPI.Data.Dtos.DtoFilme;

public class ReadFilmeDto
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
