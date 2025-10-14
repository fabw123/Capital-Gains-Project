using Cg.Console.Models;
using Cg.Console.Utils;

namespace Cg.Console.Operations
{
    public abstract class BaseOperation
    {
        protected TradeSession _session;
        public BaseOperation(TradeSession tradeSession)
        {
            _session = tradeSession;
        }
        public abstract string Type { get; }
        public virtual decimal Tax => GeneralConfiguration.TAX_PERCENTAGE;

        public abstract TaxResult Execute(TradeOperation tradeOperation);


    }
}
