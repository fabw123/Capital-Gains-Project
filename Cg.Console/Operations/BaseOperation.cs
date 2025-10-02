using Cg.Console.Models;
using Cg.Console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
