
using AnimesAPI.Data;
using AnimesAPI.Data.Dtos.PersonagensDtos;
using AnimesAPI.Models;
using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;


namespace AnimesAPI.Controllers
{
    [Route("/animes/{animeId}/personagens")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {

        private AnimesDbContext _context;
        private IMapper _mapper;

        public PersonagensController(AnimesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreatePersonagemToAnime(int animeId, [FromBody] CreatePersonagemDto personagemDto)
        {
            Anime anime = _context.Animes.FirstOrDefault(a => a.Id == animeId);
            if(anime == null)
            {
                return NotFound("Anime não encontrado");
            }
            Personagem personagem = _mapper.Map<Personagem>(personagemDto);
            personagem.AnimeId = animeId;

            _context.Personagens.Add(personagem);
            _context.SaveChanges();

            return Ok("Personagem adicionado com sucesso ao anime passado: ");
        }


        [HttpGet("/animes/{animeId}/personagens")]
        public IActionResult GetPersonagensForAnime(int animeId)
        {
            
            Anime anime = _context.Animes.FirstOrDefault(a => a.Id == animeId);
            if (anime == null)
            {
                return NotFound("Anime não encontrado");
            }

            List<Personagem> personagens = _context.Personagens
                .Where(p => p.AnimeId == animeId)
                .ToList();

            return Ok(personagens);
        }


        [HttpGet("/animes/{animeId}/personagens/{id}")]
        public IActionResult GetPersonagemForAnime(int animeId, int id)
        {
            Anime anime = _context.Animes.FirstOrDefault(a => a.Id == animeId);
            if (anime == null)
            {
                return NotFound("Anime não encontrado");
            }

            Personagem personagem = _context.Personagens
                .FirstOrDefault(p => p.AnimeId == animeId && p.Id == id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }

            return Ok(personagem);
        }


        [HttpPut("/animes/{animeId}/personagens/{id}")]
        public IActionResult UpdatePersonagemForAnime(int animeId, int id, [FromBody] UpdatePersonagemDto personagemDto)
        {

            Anime anime = _context.Animes.FirstOrDefault(a => a.Id == animeId);
            if (anime == null)
            {
                return NotFound("Anime não encontrado");
            }

            Personagem personagem = _context.Personagens
                .FirstOrDefault(p => p.AnimeId == animeId && p.Id == id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }

            _mapper.Map(personagemDto, personagem);
            _context.SaveChanges();

            return Ok("Personagem atualizado com sucesso.");
        }

        [HttpDelete("/animes/{animeId}/personagens/{id}")]
        public IActionResult DeletePersonagemForAnime(int animeId, int id)
        {
            Anime anime = _context.Animes.FirstOrDefault(a => a.Id == animeId);
            if (anime == null)
            {
                return NotFound("Anime não encontrado");
            }

            Personagem personagem = _context.Personagens
                .FirstOrDefault(p => p.AnimeId == animeId && p.Id == id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }

            _context.Personagens.Remove(personagem);
            _context.SaveChanges();

            return Ok("Personagem excluído com sucesso.");
        }

    }
}
