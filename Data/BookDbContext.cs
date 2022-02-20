using library_app.Models;
using Microsoft.EntityFrameworkCore;

namespace library_app.Data
{

    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasOne(book => book.Author);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }

}