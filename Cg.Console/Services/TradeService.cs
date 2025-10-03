using Cg.Console.Models;
using Cg.Console.Operations;

namespace Cg.Console.Services
{
    public class TradeService
    {
        private readonly TradeOperation[] _tradeOperations;

        public TradeService(TradeOperation[] tradeOperations)
        {
            _tradeOperations = tradeOperations;
        }

        public List<TaxResult> Execute()
        {
            List<TaxResult> sessionResults = [];

            var tradeSession = new TradeSession();
            BaseOperation operation;

            foreach (var trade in _tradeOperations)
            {
                operation = OperationFactory.GetOperation(trade.Operation, tradeSession);
                var resultOperation = operation.Execute(trade);
                sessionResults.Add(resultOperation);
            }

            return sessionResults;
        }
    }
}
