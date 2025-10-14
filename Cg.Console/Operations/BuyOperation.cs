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
            _session.WeightAvaragePrice = ((_session.Stock * _session.WeightAvaragePrice) + (trade.Quantity * trade.UnitCost)) / 
                (_session.Stock + trade.Quantity);

            _session.Stock = _session.Stock + trade.Quantity;
            return TaxResult.Default;
        }
    }
}
