using AutoMapper;
using FilmesAPi.Data.Dtos;
using FilmesAPi.Models;

namespace FilmesAPi.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateCinemaDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateCinemaDto, Endereco>();
    }
}
