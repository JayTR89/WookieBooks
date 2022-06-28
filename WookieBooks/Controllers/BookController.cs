using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WookieBooks.Api.Dtos;
using WookieBooks.Api.Extensions;
using WookieBooks.Api.Repositories.Interfaces;

namespace WookieBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            try
            {
                var books = await this.bookRepository.GetBooks();


                if (books == null)
                {
                    return NotFound();
                }
                else
                {
                    var bookDtos = books.ConvertToDto();
                    return Ok(bookDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            try
            {
                var book = await this.bookRepository.GetBook(id);

                if (book == null)
                {
                    return BadRequest();
                }
                else
                {
                    var bookDtos = book.ConvertToDto();
                    return Ok(bookDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook([FromBody] SaveBookDto saveBookDto)
        {
            try
            {
                var newBook = await this.bookRepository.AddBook(saveBookDto);

                if (newBook == null)
                {
                    return NoContent();
                }

                var book = await bookRepository.GetBook(newBook.Id);

                if (book == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrieve product (Book:({saveBookDto.Title})");
                }
                var newBookDto = book.ConvertToDto();
                return CreatedAtAction(nameof(GetBook), new { id = newBookDto.Id }, newBookDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BookDto>> DeleteBook(int id)
        {
            try
            {
                var deletebook = await this.bookRepository.DeleteBook(id);

                if (deletebook == null)
                {
                    return NotFound();
                }

                var book = await this.bookRepository.GetBook(deletebook.Id);

                if (book == null)
                    return NotFound();

                var deletebookDto = book.ConvertToDto();
                return Ok(deletebookDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<BookDto>> UpdateBook(int id, SaveBookDto saveBookDto)
        {
            try
            {
                var updateBook = await this.bookRepository.UpdateBook(id, saveBookDto);
                if (updateBook == null)
                {
                    return NotFound();
                }

                var book = await bookRepository.GetBook(updateBook.Id);

                var bookDto = book.ConvertToDto();

                return Ok(bookDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
