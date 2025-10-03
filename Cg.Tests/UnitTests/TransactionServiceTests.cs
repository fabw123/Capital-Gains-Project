using Cg.Console;
using Cg.Console.Exceptions;
using Cg.Console.Models;
using Cg.Console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cg.Tests.UnitTests
{

    [TestClass]
    public class TransactionServiceTests
    {
        TransactionService _transactionService;

        [TestMethod]
        public void Execute_Succeed()
        {
            Input[] transactions = [
                new Input(GeneralConfiguration.OPERATION_BUY, 100, 10),
                new Input(GeneralConfiguration.OPERATION_SELL, 200, 5),
                new Input(GeneralConfiguration.OPERATION_SELL, 250, 5),
                ];
            _transactionService = new TransactionService(transactions);
            var results = _transactionService.Execute();

            Assert.IsNotNull(results);
            Assert.AreEqual(transactions.Length, results.Count);

        }

        [TestMethod]
        public void Execute_Fail_OutOfStock()
        {
            Input[] transactions = [
                new Input(GeneralConfiguration.OPERATION_BUY, 100, 10),
                new Input(GeneralConfiguration.OPERATION_SELL, 200, 5),
                new Input(GeneralConfiguration.OPERATION_SELL, 250, 15),
                ];
            _transactionService = new TransactionService(transactions);
            Assert.ThrowsException<OutOfStockException>(()=>  _transactionService.Execute());
        }

        [TestMethod]
        public void Execute_Fail_InvalidOperation()
        {
            Input[] transactions = [
                new Input(GeneralConfiguration.OPERATION_BUY, 100, 10),
                new Input("Interchange", 200, 5)
                ];
            _transactionService = new TransactionService(transactions);
            Assert.ThrowsException<InvalidOperationException>(() => _transactionService.Execute());
        }
    }
}
