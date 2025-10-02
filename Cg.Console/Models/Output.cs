using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cg.Console.Models
{
    public record Output(decimal Tax)
    {
        public static Output Default => new(0);
    }
}
