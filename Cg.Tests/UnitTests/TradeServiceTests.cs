using Cg.Console.Exceptions;
using Cg.Console.Models;
using Cg.Console.Services;
using Cg.Console.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cg.Tests.UnitTests
{

    [TestClass]
    public class TradeServiceTests
    {
        TradeService _tradeService;

        [TestMethod]
        public void Execute_Succeed()
        {
            TradeOperation[] transactions = [
                new TradeOperation(GeneralConfiguration.OPERATION_BUY, 100, 10),
                new TradeOperation(GeneralConfiguration.OPERATION_SELL, 200, 5),
                new TradeOperation(GeneralConfiguration.OPERATION_SELL, 250, 5),
                ];
            _tradeService = new TradeService(transactions);
            var results = _tradeService.Execute();

            Assert.IsNotNull(results);
            Assert.AreEqual(transactions.Length, results.Count);

        }

        [TestMethod]
        public void Execute_Fail_OutOfStock()
        {
            TradeOperation[] transactions = [
                new TradeOperation(GeneralConfiguration.OPERATION_BUY, 100, 10),
                new TradeOperation(GeneralConfiguration.OPERATION_SELL, 200, 5),
                new TradeOperation(GeneralConfiguration.OPERATION_SELL, 250, 15),
                ];
            _tradeService = new TradeService(transactions);
            Assert.ThrowsException<OutOfStockException>(()=>  _tradeService.Execute());
        }

        [TestMethod]
        public void Execute_Fail_InvalidOperation()
        {
            TradeOperation[] transactions = [
                new TradeOperation(GeneralConfiguration.OPERATION_BUY, 100, 10),
                new TradeOperation("Interchange", 200, 5)
                ];
            _tradeService = new TradeService(transactions);
            Assert.ThrowsException<InvalidOperationException>(() => _tradeService.Execute());
        }
    }
}
