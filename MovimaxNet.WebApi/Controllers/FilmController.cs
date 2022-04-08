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
        public async Task<IEnumerable<Film>> Get()
        {
            return await _repositoryService.FilmRepository.GetAll();
        }

        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _repositoryService.FilmRepository.Get(id);
            return Ok(film);
        }

        // POST api/Film
        [HttpPost]
        public async Task<IActionResult> Post(Film film)
        {
            await _repositoryService.FilmRepository.Add(film);
            await _repositoryService.SaveChangesAsync();
            return CreatedAtAction("Get", new { film.Id }, film);

        }

        // PUT api/<FilmController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
