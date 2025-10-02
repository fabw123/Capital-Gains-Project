using Cg.Console.Models;

namespace Cg.Console.Operations
{
    public abstract class BaseOperation
    {
        protected TransactionSession _session;
        public BaseOperation(TransactionSession transactionSession)
        {
            _session = transactionSession;
        }
        public abstract string Type { get; }
        public virtual decimal Tax => GeneralConfiguration.TAX;

        public abstract Output Execute(Input input);


    }
}
