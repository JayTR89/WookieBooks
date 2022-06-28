using Microsoft.EntityFrameworkCore;
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
    }
}
