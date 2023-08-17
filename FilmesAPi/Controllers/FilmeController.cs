using AutoMapper;
using Azure;
using FilmesAPi.Data;
using FilmesAPi.Data.Dtos;
using FilmesAPi.Models;
using FilmesAPi.Profiles;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly FilmeDbContext _context;
    private readonly IMapper _mapper;

    public FilmeController(FilmeDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto"> Objeto com os campos para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso</response>
    [HttpPost("/")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaFilmeId),
            new { id = filme.Id }, filme);
    }

    [HttpGet("/")]
    public IEnumerable<ReadfilmeDto> ListFilmes()
    {
        return _mapper.Map<List<ReadfilmeDto>>(_context.Filmes);
    }

    [HttpGet("/{id:int}")]
    public IActionResult RecuperaFilmeId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null)  return NotFound(); 
        var filmeDto = _mapper.Map<ReadfilmeDto>(filme);
       
        return Ok(filmeDto);
    }
    [HttpGet]
    [Route("/{skip:int}/{take:int}")]
    public IEnumerable<Filme> RecuperaFilmes(
        [FromRoute] int skip,
        [FromRoute] int take)
    {
        return _context.Filmes.Skip(skip - 1).Take(take + 1);
    }
    [HttpPut("/{id:int}")]
    public IActionResult UpdtadeFilmeId(
        [FromRoute] int id,
        [FromBody] UpdateFilmeDto filmeDto)
    {

        var updateFilme = _context.Filmes.FirstOrDefault(x => x.Id == id);

        if (updateFilme == null) return NotFound();
        _mapper.Map(filmeDto, updateFilme);

        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("/{id:int}")]
    public IActionResult UpdateFilmeIdParcial(
        [FromRoute] int id,
        JsonPatchDocument<UpdateFilmeDto> patch)
    {

        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

        if (filme == null) return NotFound();

        var filmeUpdate = _mapper.Map<UpdateFilmeDto>(filme);

        if(patch == null ) return NotFound();

        patch.ApplyTo(filmeUpdate, ModelState);

        if (!TryValidateModel(filmeUpdate))
        {
            ValidationProblem(ModelState);
        }

        _mapper.Map(filmeUpdate, filme);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete]
    [Route("/{id:int}")]
    public IActionResult DeleteFilme(
      [FromRoute] int id)
    {

        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null) return NotFound();

        _context.Filmes.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}
