using WookieBooks.Api.Dtos;
using WookieBooks.Api.Entities;

namespace WookieBooks.Api.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBook(SaveBookDto saveBookDto);
        Task<Book> UpdateBook(int id, SaveBookDto saveBookDto);
        Task<Book> DeleteBook(int id);
        Task<Book> GetBook(int id);
        Task<IEnumerable<Book>> GetBooks();
    }
}
