using Microsoft.EntityFrameworkCore;
using BookMicroservice.Models;

namespace BookMicroservice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();  // Books is a table
    }
}
