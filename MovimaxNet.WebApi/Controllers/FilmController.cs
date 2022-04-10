using Microsoft.AspNetCore.Mvc;
using MovimaxNet.Models;
using MovimaxNet.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovimaxNet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public FilmController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        // GET: api/Film
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> Get()
        {
            var films = await _repositoryService.FilmRepository.GetAll();
            return Ok(films);
        }

        // GET api/Film/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _repositoryService.FilmRepository.Get(id);
            return Ok(film);
        }

        // POST api/Film
        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            await _repositoryService.FilmRepository.Add(film);
            await _repositoryService.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { film.Id }, film);

        }

        // PUT api/Film/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Film film)
        {
            if (film is null)
                return BadRequest(nameof(film));

            if (id != film.Id)
                return BadRequest(nameof(film));

            var existingFilm = _repositoryService.FilmRepository.Get(id);
            if(existingFilm is null)
                return NotFound();

            await _repositoryService.FilmRepository.Update(film);
            await _repositoryService.SaveChangesAsync();

            return NoContent();                
        }

        // DELETE api/Film/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var film = _repositoryService.FilmRepository.Get(id);

            if (film is null)
                return NotFound();

            await _repositoryService.FilmRepository.Delete(id);

            return NoContent();
        }
    }
}
