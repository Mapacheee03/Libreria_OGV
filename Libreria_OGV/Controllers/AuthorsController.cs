using Libreria_OGV.Data.ViewModels;
using Libreria_OGV.Data.Models;
using Libreria_OGV.Data.Sercices;
using Libreria_OGV.Data.Services;
using Microsoft.AspNetCore.Mvc;


namespace Libreria_OGV.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class AuthorsController : Controller
    {
        private AuthorsService _authorsServices;
        public AuthorsController(AuthorsService authorsServices)
        {
            _authorsServices = authorsServices;
        }
        [HttpPost("Add-author")]
        public IActionResult AddBook([FromBody] AuthorVM author)
        {
            _authorsServices.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _authorsServices.GetAuthorWithBooksVM(id);
            return Ok(response);
        }


    }
}