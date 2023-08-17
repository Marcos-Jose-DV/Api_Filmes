﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPi.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O Campo nome é obrigatório."),
        MaxLength(200, ErrorMessage = "O nome do cinana====")]
    public string Name { get; set; }
}
