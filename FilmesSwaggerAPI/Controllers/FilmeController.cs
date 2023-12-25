using AutoMapper;
using FilmesSwaggerAPI.Data;
using FilmesSwaggerAPI.Data.Dtos;
using FilmesSwaggerAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesSwaggerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados.
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme.</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso.</response>
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorID), new { id = filme.Id }, filme);
        }

        /// <summary>
        /// Obtém uma lista de filmes paginada.
        /// </summary>
        /// <param name="skip">Número de registros para pular.</param>
        /// <param name="take">Número de registros para retornar.</param>
        /// <returns>Lista de filmes.</returns>
        [HttpGet]
        public IEnumerable<ReadFilmeDto> LerFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
        }

        /// <summary>
        /// Obtém um filme por ID.
        /// </summary>
        /// <param name="id">ID do filme.</param>
        /// <returns>Filme correspondente ao ID.</returns>
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorID(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }

        /// <summary>
        /// Atualiza um filme por ID.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="filmeDto">Objeto com os campos a serem atualizados.</param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Atualiza parcialmente um filme por ID.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado parcialmente.</param>
        /// <param name="patch">Operações de patch a serem aplicadas.</param>
        /// <returns>IActionResult</returns>
        [HttpPatch("{id}")]
        public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();

            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

            patch.ApplyTo(filmeParaAtualizar, ModelState);

            if (!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(filmeParaAtualizar, filme);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deleta um filme por ID.
        /// </summary>
        /// <param name="id">ID do filme a ser deletado.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
