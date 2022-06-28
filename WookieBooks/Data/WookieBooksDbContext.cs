using Microsoft.EntityFrameworkCore;
using WookieBooks.Api.Data.EntityConfigurations;
using WookieBooks.Api.Entities;

namespace WookieBooks.Api.Data
{
    public class WookieBooksDbContext : DbContext
    {
       
        public WookieBooksDbContext(DbContextOptions<WookieBooksDbContext> options)
            : base(options)
        {

        }

        public  DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }

        //public void LoadBooks()
        //{
        //    Book book = new Book
        //    {
        //        Id = 1,
        //        Title = "Data Structure",
        //        Description = "Data Structure by Homer",
        //        Author = "Homer Simpson",
        //        CoverImage = "images/ds.png",
        //        Price = 89.99
        //    };
        //    Books.Add(book);
        //    book = new Book
        //    {
        //        Id = 2,
        //        Title = "Design Patterns",
        //        Description = "Design Patterns by Peter",
        //        Author = "Peter Griffin",
        //        CoverImage = "images/dp.png",
        //        Price = 99
        //    };
        //    Books.Add(book);
        //}
    }
}
