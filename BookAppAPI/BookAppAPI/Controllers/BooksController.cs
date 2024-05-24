using BookAppAPI.Models;
using BookAppAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _bookService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Book>> GetBook(string id)
        {
            var book = await _bookService.GetAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _bookService.CreateAsync(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> PutBook(string id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = await _bookService.GetAsync(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            await _bookService.UpdateAsync(id, book);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var book = await _bookService.GetAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookService.RemoveAsync(id);

            return NoContent();
        }
    }
}
