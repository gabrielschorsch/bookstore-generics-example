using BookStore2.Contexts;
using BookStore2.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore2.Repositories
{
    public class LivroRepository : BaseRepository<Livro>
    {
        private readonly BooksContext _context;
        public LivroRepository(BooksContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Livro> GetLivrosByAutor(string nomeAutor)
        {
            return _context.Livros
                .Include(l => l.IdAutorNavigation)
                .Where(l => l.IdAutorNavigation!.Nome == nomeAutor).ToList();
        }
    }
}
