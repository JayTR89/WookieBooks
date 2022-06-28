using Microsoft.EntityFrameworkCore;
using WookieBooks.Api.Data;
using WookieBooks.Api.Dtos;
using WookieBooks.Api.Entities;
using WookieBooks.Api.Repositories.Interfaces;

namespace WookieBooks.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly WookieBooksDbContext wookieBooksDbContext;

        public BookRepository(WookieBooksDbContext wookieBooksDbContext)
        {
            this.wookieBooksDbContext = wookieBooksDbContext;
        }

        public async Task<Book> AddBook(SaveBookDto saveBookDto)
        {
            var entity = new Book
            {
                Title = saveBookDto.Title,
                Description = saveBookDto.Description,
                Author = saveBookDto.Author,
                CoverImage = saveBookDto.CoverImage,
                Price = saveBookDto.Price
            };
            var Result=await wookieBooksDbContext.Books.AddAsync(entity);
            await wookieBooksDbContext.SaveChangesAsync();
            return Result.Entity;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = await this.wookieBooksDbContext.Books.FindAsync(id);

            if (book != null)
            {
                this.wookieBooksDbContext.Books.Remove(book);
                await this.wookieBooksDbContext.SaveChangesAsync();
            }
            return book;
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await wookieBooksDbContext.Books.SingleOrDefaultAsync(c => c.Id == id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await this.wookieBooksDbContext.Books.ToListAsync();
            return books;
        }

        public async Task<Book> UpdateBook(int id, SaveBookDto saveBookDto)
        {
            var book = await this.wookieBooksDbContext.Books.FindAsync(id);

            if (book != null)
            {
                book.Title = saveBookDto.Title;
                book.Description = saveBookDto.Description;
                book.Author = saveBookDto.Author;
                book.CoverImage = saveBookDto.CoverImage;
                book.Price = saveBookDto.Price;
                await this.wookieBooksDbContext.SaveChangesAsync();
                return book;
            }
            return null;
        }
    }
}
