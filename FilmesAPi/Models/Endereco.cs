using System.ComponentModel.DataAnnotations;

namespace FilmesAPi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Largadouro { get; set; }
    public int Numero { get; set; }

    public virtual Cinema  Ciname { get; set; }

}
