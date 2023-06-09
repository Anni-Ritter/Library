using DDDLibrary.Domain.AggregationModels.BookReservation;
using DDDLibrary.Domain.AggregationModels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Application.Service
{
    public class BookReservationService
    {
        private List<BooksReservation> reservations;

        public BookReservationService()
        {
            reservations = new List<BooksReservation>();
        }

        public void ReserveBook(Book book, Reader reader)
        {
            var reservation = new BooksReservation
            {
                ReservedBook = book,
                ReservedBy = reader,
                ReservationDate = DateTime.Now
            };

            reservations.Add(reservation);
        }

        public void CancelReservation(BooksReservation reservation)
        {
            reservations.Remove(reservation);
        }
    }
}
