using Libreria_OGV.Data.ViewModels;
using Libreria_OGV.Data.Sercices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_OGV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _booksService.GetAllBks();
            return Ok(allbooks);
        }

        [HttpGet("get-book-by-id/{Id}")]//importante "Id" tiene que estar escrito exactamente como la variable de abajo
        public IActionResult GetBookById(int Id)//importante "Id" tiene que estar escrito exactamente como la variable de arriba
        {
            var book = _booksService.GetBookById(Id);
            return Ok(book);
        }

        [HttpPost("Add-Book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updateBook = _booksService.UpdateBookByID(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("update-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookbyId(id);
            return Ok();
        }
    }
}
