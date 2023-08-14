using AnimesAPI.Data.Dtos.AnimesDtos;
using AnimesAPI.Data;
using AnimesAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private AnimesDbContext _context;
        private IMapper _mapper;

        public AnimesController(AnimesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateAnime([FromBody] CreateAnimeDto animeDto)
        {
            Anime anime = _mapper.Map<Anime>(animeDto);
            _context.Add(anime);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IEnumerable<ReadAnimeDto> ReadAnimes()
        {
            return _mapper.Map<List<ReadAnimeDto>>(_context.Animes);
        }

        [HttpGet("{id}")]
        public IActionResult ReadAnimesId(int id)
        {
            var anime = _context.Animes.FirstOrDefault(task => task.Id == id);
            if (anime == null) return NotFound();

            var animeDto = _mapper.Map<ReadAnimeDto>(anime);
            return Ok(animeDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnime(int id, [FromBody] UpdateAnimeDto animeDto)
        {
            var anime = _context.Animes
                .FirstOrDefault(anime => anime.Id == id);
            if (_context.Animes == null) return NotFound();
            _mapper.Map(animeDto, anime);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnime(int id)
        {
            var anime = _context.Animes.FirstOrDefault(anime => anime.Id == id);
            if (_context.Animes == null) return NotFound();

            _context.Remove(anime);
            _context.SaveChanges();
            return NoContent();

        }


    }
}
//Animes:
//GET / animes: Retorna todos os animes
//GET /animes/{id}: Retorna um anime específico pelo ID
//POST /animes: Adiciona um novo anime
//PUT /animes/{id}: Atualiza um anime específico pelo ID
//DELETE /animes/{id}: Exclui um anime específico pelo ID
//GET /animes/{animeId}/ personagens: Retorna todos os personagens de um anime específico
//GET /animes/{animeId}/ personagens /{ id}: Retorna um personagem específico de um anime
//POST /animes/{animeId}/ personagens: Adiciona um novo personagem a um anime específico
//PUT /animes/{animeId}/ personagens /{ id}: Atualiza um personagem de um anime específico
//DELETE /animes/{animeId}/ personagens /{ id}: Exclui um personagem de um anime específico