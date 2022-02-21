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
                .HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);
            // .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Collection>()
                .HasOne(collection => collection.Book)
                .WithMany(book => book.Collections)
                .HasForeignKey(collection => collection.BookId);

            builder.Entity<Collection>()
                .HasOne(collection => collection.Genre)
                .WithMany(genre => genre.Collections)
                .HasForeignKey(collection => collection.GenreId);


        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Collection> Collections { get; set; }
    }

}