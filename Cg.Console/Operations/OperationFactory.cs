using Cg.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
                _ => throw new Exception(),
            };

            return operation;
        }
    }
}
