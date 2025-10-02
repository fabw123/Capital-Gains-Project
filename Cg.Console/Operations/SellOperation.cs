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
    public class SellOperation : BaseOperation
    {
        public SellOperation(TransactionSession transactionSession) : base(transactionSession)
        {
        }

        public override string Type => GeneralConfiguration.OPERATION_SELL;

        public override Output Execute(Input transaction)
        {
            _session.Stock = _session.Stock - transaction.Quantity;
            var totalAmount = (transaction.Quantity * transaction.UnitCost);
            var totalProfit = (totalAmount - (transaction.Quantity * _session.WeightAvaragePrice));

            if (totalProfit < 0)
            {
                _session.Looses = _session.Looses + totalProfit;
                return Output.Default;
            }

            if (totalAmount > GeneralConfiguration.TAX_EXCEPTION_LIMIT)
            {
                if (_session.Looses < 0)
                {
                    totalProfit = totalProfit + _session.Looses;
                }

                if (totalProfit < 0)
                {
                    _session.Looses = totalProfit;
                    return Output.Default;
                }

                _session.Looses = 0;
                return new Output( totalProfit * (Tax/100) );
            }

           
            return Output.Default;
        }
    }
}
