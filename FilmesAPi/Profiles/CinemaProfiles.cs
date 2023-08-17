using AutoMapper;
using FilmesAPi.Data.Dtos;
using FilmesAPi.Models;

namespace FilmesAPi.Profiles

{
    public class CinemaProfiles : Profile
    {
        public CinemaProfiles()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
            CreateMap<Cinema, UpdateCinemaDto>();
            CreateMap<Cinema, ReadCinemaDto>();
        }
    }
}
