using DDDLibrary.Domain.AggregationModels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Application.Handlers
{
    public class BookAddedEventArgs : EventArgs
    {
        public Book AddedBook { get; }

        public BookAddedEventArgs(Book book)
        {
            AddedBook = book;
        }
    }
}
