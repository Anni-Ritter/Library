using DDDLibrary.Application.Commands;
using DDDLibrary.Application.Service;
using DDDLibrary.Domain.AggregationModels.LibraryCatalog;
using DDDLibrary.Domain.AggregationModels.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DDD_Library.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private LibraryCatalogService catalogService;

        public LibraryController()
        {
            var libraryCatalog = new LibraryCatalog();
            catalogService = new LibraryCatalogService(libraryCatalog);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            catalogService.AddBook(book);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            catalogService.AddAuthor(author);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = catalogService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = catalogService.GetBookById(id);
            if (book == null)
            {
                return NotFound("Book not found.");
            }
            return Ok(book);
        }

        [HttpGet("authors/{authorName}/books")]
        public IActionResult GetBooksByAuthor(string authorName)
        {
            var books = catalogService.GetBooksByAuthor(authorName);
            return Ok(books);
        }

        [HttpGet("readers/{readerId}/reservations")]
        public IActionResult GetReservationsByReaderId(int readerId)
        {
            var reservations = catalogService.GetReservationsByReaderId(readerId);
            return Ok(reservations);
        }

        [HttpPost("cancel-reservation")]
        public IActionResult CancelReservation([FromBody] CancelReservationCommand command)
        {
            catalogService.CancelReservation(command.ReservationId);
            return Ok();
        }
    }
}
