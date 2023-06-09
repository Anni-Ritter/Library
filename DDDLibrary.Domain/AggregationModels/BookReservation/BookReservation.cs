using DDDLibrary.Domain.AggregationModels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Domain.AggregationModels.BookReservation
{
    public class BooksReservation
    {
        public Book ReservedBook { get; set; }
        public Reader ReservedBy { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Id { get; set; }
    }
}
