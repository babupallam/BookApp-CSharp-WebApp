using BookAppAPI.Models;
using BookAppAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BookAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _authorService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Author>> GetAuthor(string id)
        {
            var author = await _authorService.GetAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            await _authorService.CreateAsync(author);
            author.Id = ObjectId.GenerateNewId().ToString();

            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> PutAuthor(string id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            var existingAuthor = await _authorService.GetAsync(id);

            if (existingAuthor == null)
            {
                return NotFound();
            }

            await _authorService.UpdateAsync(id, author);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            var author = await _authorService.GetAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            await _authorService.RemoveAsync(id);

            return NoContent();
        }
    }
}
