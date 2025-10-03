using Cg.Console.Exceptions;
using Cg.Console.Models;
using Cg.Console.Utils;

namespace Cg.Console.Operations
{
    public class SellOperation : BaseOperation
    {
        public SellOperation(TradeSession transactionSession) : base(transactionSession)
        {
        }

        public override string Type => GeneralConfiguration.OPERATION_SELL;

        public override TaxResult Execute(TradeOperation trade)
        {
            _session.Stock = _session.Stock - trade.Quantity;

            if (_session.Stock < 0) 
            {
                throw new OutOfStockException(ErrorMessages.NOT_ENOUGH_STOCK);
            }

            var totalAmount = (trade.Quantity * trade.UnitCost);
            var totalProfit = (totalAmount - (trade.Quantity * _session.WeightAvaragePrice));

            if (totalProfit < 0)
            {
                _session.Losses = _session.Losses + totalProfit;
                return TaxResult.Default;
            }

            if (totalAmount > GeneralConfiguration.TAX_EXCEPTION_LIMIT)
            {
                if (_session.Losses < 0)
                {
                    totalProfit = totalProfit + _session.Losses;
                }

                if (totalProfit < 0)
                {
                    _session.Losses = totalProfit;
                    return TaxResult.Default;
                }

                _session.Losses = 0;
                return new TaxResult( totalProfit * Tax );
            }

            return TaxResult.Default;
        }
    }
}
