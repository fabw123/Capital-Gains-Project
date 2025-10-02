using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cg.Console.Models
{
    public record TransactionSession
    {
        public TransactionSession()
        {
            Stock = 0;
            WeightAvaragePrice = 0;
            Looses = 0;
        }

        public int Stock { get; set; }

        public decimal WeightAvaragePrice { get; set; }

        public decimal Looses { get; set; }
    }
}
