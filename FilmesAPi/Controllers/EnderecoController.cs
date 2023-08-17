using AutoMapper;
using FilmesAPi.Data;
using FilmesAPi.Data.Dtos;
using FilmesAPi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPi.Controllers;

[ApiController]
[Route("Controller")]
public class EnderecoController : ControllerBase
{
    private readonly FilmeDbContext _context;
    private readonly IMapper _mapper;

    public EnderecoController(FilmeDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
    }
    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperaEndereco()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }

    [HttpGet("{id}")]
    private object RecuperaEnderecoPorId([FromServices] int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

        if(endereco != null)
        {
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return Ok(enderecoDto);
        }
        return NotFound();

    }
    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco([FromServices] int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

        if (endereco == null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDto, endereco);
        _context.SaveChanges();

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteCinema([FromServices] int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
