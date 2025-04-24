using BookMicroservice.Models;
using BookMicroservice.Data;
using Microsoft.EntityFrameworkCore;

namespace BookMicroservice.Services
{
    public class BookService  // has the actual methods for crud operations
    {
        private readonly AppDbContext _context;  // db connection

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync() => await _context.Books.ToListAsync();

        public async Task<Book?> GetByIdAsync(int id) => await _context.Books.FindAsync(id);

        public async Task AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteBookAsync(int id)
{
    var book = await _context.Books.FindAsync(id);
    if (book == null)
        return false;

    _context.Books.Remove(book);
    await _context.SaveChangesAsync(); 
    return true;
}

    }
}
