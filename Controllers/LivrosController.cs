using BookStore2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivrosController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_livroRepository.GetAll());
        }

        [HttpGet("autor")]
        public IActionResult GetByAuthor(string nomeAutor)
        {
            return Ok(_livroRepository.GetLivrosByAutor(nomeAutor));
        }
    }
}
