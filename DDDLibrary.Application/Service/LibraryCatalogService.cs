using DDDLibrary.Application.Handlers;
using DDDLibrary.Domain.AggregationModels.BookReservation;
using DDDLibrary.Domain.AggregationModels.LibraryCatalog;
using DDDLibrary.Domain.AggregationModels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Application.Service
{
    public class LibraryCatalogService
    {
        private LibraryCatalog libraryCatalog;

        public LibraryCatalogService(LibraryCatalog catalog)
        {
            libraryCatalog = catalog;

            libraryCatalog.BookAdded += HandleBookAdded;
            libraryCatalog.BookReserved += HandleBookReserved;
            libraryCatalog.BookReservationCancelled += HandleBookReservationCancelled;
        }

        private void HandleBookAdded(object sender, BookAddedEventArgs e)
        {
            Book addedBook = e.AddedBook;
            SendNotificationToAdministrator($"Новая книга добавлена: {addedBook.Title}");
        }

        private void SendNotificationToAdministrator(string message)
        {
            //TODO
        }

        private void HandleBookReserved(object sender, BookReservedEventArgs e)
        {
            Book reservedBook = e.ReservedBook;
            Reader reservedBy = e.ReservedBy;
            UpdateBookAvailability(reservedBook);
            SendNotificationToReader(reservedBy, $"Книга {reservedBook.Title} забронирована");
        }

        private void UpdateBookAvailability(Book book)
        {
            //TODO
        }

        private void SendNotificationToReader(Reader reader, string message)
        {
            //TODO
        }

        private void HandleBookReservationCancelled(object sender, BookReservationCancelledEventArgs e)
        {
            Book cancelledBook = e.CancelledBook;
            Reader cancelledBy = e.CancelledBy;
            UpdateBookAvailability(cancelledBook);
            SendNotificationToReader(cancelledBy, $"Бронирование книги {cancelledBook.Title} отменено");
        }

        public void AddBook(Book book)
        {
            libraryCatalog.Books.Add(book);
        }

        public Book GetBookById(int bookId)
        {
            return libraryCatalog.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public List<Book> GetBooksByAuthor(string authorName)
        {
            var author = libraryCatalog.Authors.FirstOrDefault(a => a.Name == authorName);
            if (author != null)
            {
                return libraryCatalog.Books.Where(b => b.Id == author.Id).ToList();
            }
            return new List<Book>();
        }

        public List<BooksReservation> GetReservationsByReaderId(int readerId)
        {
            return libraryCatalog.Reservations
                .Where(r => r.ReservedBy.Id == readerId)
                .ToList();
        }

        public void AddAuthor(Author author)
        {
            libraryCatalog.Authors.Add(author);
        }

        public List<Book> GetAllBooks()
        {
            return libraryCatalog.Books;
        }

        public void CancelReservation(int reservationId)
        {
            var reservation = libraryCatalog.Reservations.FirstOrDefault(r => r.Id == reservationId);
            if (reservation != null)
            {
                libraryCatalog.Reservations.Remove(reservation);
            }
        }
    }
}
