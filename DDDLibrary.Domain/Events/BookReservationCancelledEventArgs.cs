using DDDLibrary.Domain.AggregationModels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Application.Handlers
{
    public class BookReservationCancelledEventArgs : EventArgs
    {
        public Book CancelledBook { get; }
        public Reader CancelledBy { get; }

        public BookReservationCancelledEventArgs(Book book, Reader reader)
        {
            CancelledBook = book;
            CancelledBy = reader;
        }
    }
}
