using WookieBooks.Api.Entities;

namespace WookieBooks.Api.Data
{
    public class WookieBooksContextSeed
    {
        private readonly WookieBooksDbContext wookieBooksDbContext;

        public WookieBooksContextSeed(WookieBooksDbContext wookieBooksDbContext)
        {
            this.wookieBooksDbContext = wookieBooksDbContext;
        }

        public void SeedData(WookieBooksDbContext wookieBooksDbContext)
        {
            if (!wookieBooksDbContext.Books.Any())
            {
                var books = new List<Book>
                {
                    new Book
                    {
                        Title="Data Structure",
                        Description="Data Structure by Homer",
                        Author="Homer Simpson",
                        CoverImage="images/ds.png",
                        Price=89.99
                    },
                     new Book
                    {
                        Title="Design Patterns",
                        Description="Design Patterns by Peter",
                        Author="Peter Griffin",
                        CoverImage="images/dp.png",
                        Price=99
                    }
                };
                wookieBooksDbContext.Books.AddRange(books);
                wookieBooksDbContext.SaveChanges();
            }
        }
    }
}
