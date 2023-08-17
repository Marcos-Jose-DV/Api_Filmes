using FilmesAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPi.Data;

public class FilmeDbContext : DbContext
{
    public FilmeDbContext(DbContextOptions <FilmeDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }

}
