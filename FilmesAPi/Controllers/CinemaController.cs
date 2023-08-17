using AutoMapper;
using FilmesAPi.Data;
using FilmesAPi.Data.Dtos;
using FilmesAPi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPi.Controllers;

[ApiController]
[Route("Controller")]
public class CinemaController : ControllerBase
{
    private readonly FilmeDbContext _context;
    private readonly IMapper _mapper;

    public CinemaController(IMapper mapper, FilmeDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult AddCiname([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinemaDto);

    }
    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperaCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorId([FromServices] int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

        if (cinema != null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

            return Ok(cinemaDto);
        }
        return NotFound();
    }
    [HttpPut("{id}")]
    public IActionResult AtualizaCinema([FromServices] int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

        if (cinema == null)
        {

            return NotFound();

        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteCinema([FromServices] int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}
