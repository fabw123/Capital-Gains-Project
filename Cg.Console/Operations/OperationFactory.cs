using Cg.Console.Exceptions;
using Cg.Console.Models;

namespace Cg.Console.Operations
{
    public class OperationFactory
    {
        public static BaseOperation GetOperation(string operationType, TransactionSession transactionSession)
        {
            operationType = operationType.ToLower();
            BaseOperation operation = operationType switch
            {
                GeneralConfiguration.OPERATION_BUY => new BuyOperation(transactionSession),
                GeneralConfiguration.OPERATION_SELL => new SellOperation(transactionSession),
                _ => throw new InvalidOperationException($"Operation {operationType} is currently unavailable.")
            };

            return operation;
        }
    }
}
