using AutoMapper;
using FilmesAPi.Data.Dtos;
using FilmesAPi.Models;

namespace FilmesAPi.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadfilmeDto>();
    }
}
