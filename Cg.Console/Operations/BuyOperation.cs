using Cg.Console.Models;
using Cg.Console.Utils;

namespace Cg.Console.Operations
{
    public class BuyOperation : BaseOperation
    {
        public BuyOperation(TradeSession tradeSession) : base(tradeSession)
        {
        }

        public override string Type => GeneralConfiguration.OPERATION_BUY;

        public override TaxResult Execute(TradeOperation trade)
        {
            var stockTypeQuantity = _session.Stock[trade.Type];
            _session.WeightAvaragePrice = ((stockTypeQuantity * _session.WeightAvaragePrice) + (trade.Quantity * trade.UnitCost)) / 
                (stockTypeQuantity + trade.Quantity);

            _session.Stock[trade.Type] = stockTypeQuantity + trade.Quantity;
            return TaxResult.Default;
        }
    }
}
