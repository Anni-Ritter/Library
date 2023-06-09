using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Domain.AggregationModels.ValueObjects
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublishing { get; set; }
        public string Genre { get; set; }
        public Author Author { get; set; }
    }
}
