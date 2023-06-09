using DDDLibrary.Application.Handlers;
using DDDLibrary.Domain.AggregationModels.BookReservation;
using DDDLibrary.Domain.AggregationModels.ValueObjects;

namespace DDDLibrary.Domain.AggregationModels.LibraryCatalog
{
    public class LibraryCatalog
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<BooksReservation> Reservations { get; set; }

        public event EventHandler<BookAddedEventArgs> BookAdded;
        public event EventHandler<BookReservedEventArgs> BookReserved;
        public event EventHandler<BookReservationCancelledEventArgs> BookReservationCancelled;

        public void AddBook(Book book)
        {
            Books.Add(book);
            OnBookAdded(new BookAddedEventArgs(book));
        }

        protected virtual void OnBookAdded(BookAddedEventArgs e)
        {
            BookAdded?.Invoke(this, e);
        }

        public void ReserveBook(Book book, Reader reader)
        {
            OnBookReserved(new BookReservedEventArgs(book, reader));
        }

        protected virtual void OnBookReserved(BookReservedEventArgs e)
        {
            BookReserved?.Invoke(this, e);
        }

        public void CancelReservation(Book book, Reader reader)
        {
            OnBookReservationCancelled(new BookReservationCancelledEventArgs(book, reader));
        }

        protected virtual void OnBookReservationCancelled(BookReservationCancelledEventArgs e)
        {
            BookReservationCancelled?.Invoke(this, e);
        }

        public List<Book> GetBooksByAuthor(string authorName)
        {
            var author = Authors.FirstOrDefault(a => a.Name == authorName);
            if (author != null)
            {
                Console.WriteLine(author + " don't find");
            }
            return new List<Book>();
        }
    }
}
