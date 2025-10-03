using Cg.Console.Models;
using Cg.Console.Operations;
using Cg.Console.Utils;

namespace Cg.Tests.UnitTests
{
    [TestClass]
    public class BuyOperationTests
    {
        [TestMethod]
        public void Execute_Succeed()
        {
            var session = new TradeSession()
            {
                Losses = 0,
                Stock = 0,
                WeightAvaragePrice = 0,
            };

            var operation = new BuyOperation(session);
            var transaction = new TradeOperation(GeneralConfiguration.OPERATION_BUY, 100, 20);
            var result = operation.Execute(transaction);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Tax);
            Assert.AreEqual(session.WeightAvaragePrice, transaction.UnitCost);
            Assert.AreEqual(session.Stock, transaction.Quantity);
        }

        [TestMethod]
        public void Execute_Succeed_CurrentStock()
        {
            decimal initialWAP = 50;
            int initialStock = 20;
            var session = new TradeSession()
            {
                Losses = 0,
                Stock = initialStock,
                WeightAvaragePrice = initialWAP,
            };

            var operation = new BuyOperation(session);
            var transaction = new TradeOperation(GeneralConfiguration.OPERATION_BUY, 100, 20);
            var result = operation.Execute(transaction);

            var expectedStock = initialStock + transaction.Quantity;
            var expectedWAP = (initialWAP + transaction.UnitCost) / 2;

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Tax);
            Assert.AreEqual(expectedWAP, session.WeightAvaragePrice);
            Assert.AreEqual(expectedStock, session.Stock);
        }
    }
}
