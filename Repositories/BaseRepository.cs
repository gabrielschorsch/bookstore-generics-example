using BookStore2.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly BooksContext _context;

        public BaseRepository(BooksContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
