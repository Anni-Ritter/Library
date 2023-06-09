using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDLibrary.Application.Commands
{
    public class ReserveBookCommand
    {
        public int BookId { get; set; }
        public int ReaderId { get; set; }
    }
}
