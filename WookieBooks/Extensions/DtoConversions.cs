using WookieBooks.Api.Dtos;
using WookieBooks.Api.Entities;

namespace WookieBooks.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<BookDto> ConvertToDto(this IEnumerable<Book> books)
        {
            return (from book in books
                    select new BookDto
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        Author = book.Author,
                        CoverImage = book.CoverImage,
                        Price = book.Price
                    }).ToList();

        }
        public static BookDto ConvertToDto(this Book book)

        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                CoverImage = book.CoverImage,
                Price = book.Price
            };

        }
    }
}
