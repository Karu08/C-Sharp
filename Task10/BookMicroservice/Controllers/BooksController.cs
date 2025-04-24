using BookMicroservice.Models;
using BookMicroservice.Services;
using Microsoft.AspNetCore.Mvc;  //Core Web API features 

namespace BookMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null) return NotFound();
            return book;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
            await _service.AddAsync(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteBookAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
