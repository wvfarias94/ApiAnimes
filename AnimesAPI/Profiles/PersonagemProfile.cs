using AnimesAPI.Data.Dtos.PersonagensDtos;
using AnimesAPI.Models;
using AutoMapper;

namespace AnimesAPI.Profiles
{
    public class PersonagemProfile : Profile
    {

        public PersonagemProfile()
        {
            CreateMap<CreatePersonagemDto, Personagem>();
            CreateMap<UpdatePersonagemDto, Personagem>();
            CreateMap<Personagem, UpdatePersonagemDto>();
            CreateMap<Personagem, ReadPersonagemDto>();


        }
    }
}
