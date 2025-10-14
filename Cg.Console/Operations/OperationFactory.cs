using Cg.Console.Exceptions;
using Cg.Console.Models;
using Cg.Console.Utils;

namespace Cg.Console.Operations
{
    public class OperationFactory
    {
        public static BaseOperation GetOperation(string operationType, TradeSession tradeSession)
        {
            operationType = operationType.ToLower();
            BaseOperation operation = operationType switch
            {
                GeneralConfiguration.OPERATION_BUY => new BuyOperation(tradeSession),
                GeneralConfiguration.OPERATION_SELL => new SellOperation(tradeSession),
                _ => throw new InvalidOperationException(string.Format(ErrorMessages.INVALID_OPERATION, operationType))
            };

            return operation;
        }
    }
}
