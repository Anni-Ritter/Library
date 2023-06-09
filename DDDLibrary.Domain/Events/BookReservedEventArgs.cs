using DDDLibrary.Domain.AggregationModels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Application.Handlers
{
    public class BookReservedEventArgs : EventArgs
    {
        public Book ReservedBook { get; }
        public Reader ReservedBy { get; }

        public BookReservedEventArgs(Book book, Reader reader)
        {
            ReservedBook = book;
            ReservedBy = reader;
        }
    }
}
