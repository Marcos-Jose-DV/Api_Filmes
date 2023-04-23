﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O título do filme e obrigatorio")]
    [MaxLength(50, ErrorMessage = "O maxímo de carctere e 50")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O género do filme e obrigatorio")]
    [MaxLength(50, ErrorMessage = "O maxímo de caractere e 50")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O duração do filme e obrigatorio")]
    [Range(60, 600, ErrorMessage = "A duração deve ter entre 60 e 600")]
    public int Duracao { get; set; }
}
