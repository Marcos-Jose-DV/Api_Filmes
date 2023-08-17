using System.ComponentModel.DataAnnotations;

namespace FilmesAPi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O Campo nome é obrigatório.")]
    public string Name { get; set; }
}
