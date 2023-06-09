using DDDLibrary.Domain.AggregationModels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Application.Commands
{
    public class AddAuthorCommand
    {
        public Author Author { get; set; }
    }
}
