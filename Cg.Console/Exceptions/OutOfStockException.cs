using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cg.Console.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class OutOfStockException: Exception
    {

        public OutOfStockException(string message)
            : base(message)
        {
        }

        public OutOfStockException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
