using AnimesAPI.Data.Dtos.AnimesDtos;
using AnimesAPI.Models;
using AutoMapper;

namespace AnimesAPI.Profiles
{
    public class AnimeProfile : Profile
    {

        public AnimeProfile()
        {
            CreateMap<CreateAnimeDto, Anime>();
            CreateMap<UpdateAnimeDto, Anime>();
            CreateMap<Anime, UpdateAnimeDto>();
            CreateMap<Anime, ReadAnimeDto>();


        }
    }
}
