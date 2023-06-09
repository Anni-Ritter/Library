using DDDLibrary.Application.Service;
using DDDLibrary.Domain.AggregationModels.BookReservation;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DDD_Library.Controllers
{
    [ApiController]
    [Route("v1/api/library-requests")]
    [Produces("application/json")]
    public class ReservationController : ControllerBase
    {
        private BookReservationService reservationService;

        public ReservationController()
        {
            reservationService = new BookReservationService();
        }

        [HttpPost]
        public IActionResult ReserveBook([FromBody] BooksReservation reservation)
        {
            var book = reservation.ReservedBook;
            var reader = reservation.ReservedBy;

            reservationService.ReserveBook(book, reader);
            return Ok();
        }

        
    }
}
