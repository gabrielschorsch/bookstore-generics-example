using BookStore2.Contexts;
using BookStore2.Models;
using BookStore2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly BaseRepository<Autore> _autorRepository;
        private readonly BooksContext _context;

        public AutoresController(BaseRepository<Autore> autorRepository, BooksContext ctx)
        {
            _autorRepository = autorRepository;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_autorRepository.GetAll());
        }

        [HttpGet("semRepository")]
        public IActionResult GetSemRepository()
        {
            return Ok(_context.Autores.ToList());
        }
    }
}
