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
    public class BuyOperation : BaseOperation
    {
        public BuyOperation(TransactionSession transactionSession) : base(transactionSession)
        {
        }

        public override string Type => GeneralConfiguration.OPERATION_BUY;

        public override Output Execute(Input transaction)
        {
            _session.WeightAvaragePrice = ((_session.Stock * _session.WeightAvaragePrice) + (transaction.Quantity * transaction.UnitCost)) / 
                (_session.Stock + transaction.Quantity);

            _session.Stock = _session.Stock + transaction.Quantity;
            return Output.Default;
        }
    }
}
