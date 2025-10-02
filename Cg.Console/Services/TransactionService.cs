using Cg.Console.Models;
using Cg.Console.Operations;

namespace Cg.Console.Services
{
    public class TransactionService
    {
        private readonly Input[] _transactions;

        public TransactionService(Input[] transactions)
        {
            _transactions = transactions;
        }

        public List<Output> Execute()
        {
            List<Output> sessionResults = [];

            var transactionSession = new TransactionSession();
            BaseOperation operation;

            foreach (var transaction in _transactions)
            {
                operation = OperationFactory.GetOperation(transaction.Operation, transactionSession);
                var resultOperation = operation.Execute(transaction);
                sessionResults.Add(resultOperation);
            }

            return sessionResults;
        }


    }
}
