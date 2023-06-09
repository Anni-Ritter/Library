using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Domain.AggregationModels.ValueObjects
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Birthday { get; set; }
        public string Gender { get; set; }
    }
}
