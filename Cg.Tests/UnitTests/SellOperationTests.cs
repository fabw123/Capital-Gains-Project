using Cg.Console.Exceptions;
using Cg.Console.Models;
using Cg.Console.Operations;
using Cg.Console.Utils;

namespace Cg.Tests.UnitTests
{

    [TestClass]
    public class SellOperationTests
    {
        SellOperation operation;
        TradeSession session;

        [TestMethod]
        public void Execute_Succeed()
        {
            int initialStock = 300;
            decimal initialWAP = 100;
            session = new TradeSession()
            {
                Stock = initialStock,
                WeightAvaragePrice = initialWAP,
                Losses = 0
            };
            TradeOperation transaction = new(GeneralConfiguration.OPERATION_SELL, 200, 300);
            
            decimal costOfStock = session.WeightAvaragePrice * transaction.Quantity;
            decimal profitOfTransaction = (transaction.Quantity * transaction.UnitCost) - costOfStock;
            decimal expectedTax = profitOfTransaction * GeneralConfiguration.TAX_PERCENTAGE;
            int expectedStock = initialStock - transaction.Quantity;

            operation = new SellOperation(session);
            var taxResult = operation.Execute(transaction);

            Assert.IsNotNull(taxResult);
            Assert.AreEqual(expectedTax, taxResult.Tax);
            Assert.AreEqual(expectedStock, session.Stock);
            Assert.AreEqual(initialWAP, session.WeightAvaragePrice);
        }

        [TestMethod]
        public void Execute_Succeed_UnderTaxExceptionLimit()
        {
            int initialStock = 300;
            decimal initialWAP = 100;
            session = new TradeSession()
            {
                Stock = initialStock,
                WeightAvaragePrice = initialWAP,
                Losses = 0
            };
            TradeOperation transaction = new(GeneralConfiguration.OPERATION_SELL, 200, 50);

            decimal costOfStock = session.WeightAvaragePrice * transaction.Quantity;
            decimal profitOfTransaction = (transaction.Quantity * transaction.UnitCost) - costOfStock;
            decimal expectedTax = profitOfTransaction * GeneralConfiguration.TAX_PERCENTAGE;
            int expectedStock = initialStock - transaction.Quantity;

            operation = new SellOperation(session);
            var taxResult = operation.Execute(transaction);

            Assert.IsNotNull(taxResult);
            Assert.AreEqual(0, taxResult.Tax);
            Assert.AreEqual(expectedStock, session.Stock);
            Assert.AreEqual(initialWAP, session.WeightAvaragePrice);
        }

        [TestMethod]
        public void Execute_Succeed_LoosesProfit()
        {
            int initialStock = 300;
            decimal initialWAP = 100;
            session = new TradeSession()
            {
                Stock = initialStock,
                WeightAvaragePrice = initialWAP,
                Losses = 0
            };
            TradeOperation transaction = new(GeneralConfiguration.OPERATION_SELL, 90, 300);

            decimal costOfStock = session.WeightAvaragePrice * transaction.Quantity;
            decimal profitOfTransaction = (transaction.Quantity * transaction.UnitCost) - costOfStock;
            decimal expectedTax = 0;
            int expectedStock = initialStock - transaction.Quantity;

            operation = new SellOperation(session);
            var taxResult = operation.Execute(transaction);

            Assert.IsNotNull(taxResult);
            Assert.AreEqual(expectedTax, taxResult.Tax);
            Assert.AreEqual(expectedStock, session.Stock);
            Assert.AreEqual(initialWAP, session.WeightAvaragePrice);
            Assert.AreEqual(profitOfTransaction, session.Losses);
        }

        [TestMethod]
        public void Execute_Succeed_DeductingLooses()
        {
            int initialStock = 300;
            decimal initialWAP = 100;
            session = new TradeSession()
            {
                Stock = initialStock,
                WeightAvaragePrice = initialWAP,
                Losses = -20000
            };
            TradeOperation transaction = new(GeneralConfiguration.OPERATION_SELL, 200, 300);

            decimal costOfStock = session.WeightAvaragePrice * transaction.Quantity;
            decimal profitOfTransaction = (transaction.Quantity * transaction.UnitCost) - costOfStock;
            decimal loosesDeducted = profitOfTransaction + session.Losses;
            decimal expectedTax = loosesDeducted * GeneralConfiguration.TAX_PERCENTAGE;
            int expectedStock = initialStock - transaction.Quantity;

            operation = new SellOperation(session);
            var taxResult = operation.Execute(transaction);

            Assert.IsNotNull(taxResult);
            Assert.AreEqual(expectedTax, taxResult.Tax);
            Assert.AreEqual(expectedStock, session.Stock);
            Assert.AreEqual(initialWAP, session.WeightAvaragePrice);
        }

        [TestMethod]
        public void Execute_Succeed_DeductingLooses_NoTaxes()
        {
            int initialStock = 300;
            decimal initialWAP = 100;
            session = new TradeSession()
            {
                Stock = initialStock,
                WeightAvaragePrice = initialWAP,
                Losses = -80000
            };
            TradeOperation transaction = new(GeneralConfiguration.OPERATION_SELL, 200, 300);

            decimal costOfStock = session.WeightAvaragePrice * transaction.Quantity;
            decimal profitOfTransaction = (transaction.Quantity * transaction.UnitCost) - costOfStock;
            decimal loosesDeducted = profitOfTransaction + session.Losses;
            decimal expectedTax = loosesDeducted * GeneralConfiguration.TAX_PERCENTAGE;
            int expectedStock = initialStock - transaction.Quantity;

            operation = new SellOperation(session);
            var taxResult = operation.Execute(transaction);

            Assert.IsNotNull(taxResult);
            Assert.AreEqual(0, taxResult.Tax);
            Assert.AreEqual(expectedStock, session.Stock);
            Assert.AreEqual(initialWAP, session.WeightAvaragePrice);
        }

        [TestMethod]
        public void Execute_Fail_OutOfStock()
        {
            int initialStock = 300;
            decimal initialWAP = 100;
            session = new TradeSession()
            {
                Stock = initialStock,
                WeightAvaragePrice = initialWAP,
                Losses = 0
            };
            TradeOperation transaction = new(GeneralConfiguration.OPERATION_SELL, 200, 400);

            decimal costOfStock = session.WeightAvaragePrice * transaction.Quantity;
            decimal profitOfTransaction = (transaction.Quantity * transaction.UnitCost) - costOfStock;
            decimal expectedTax = profitOfTransaction * GeneralConfiguration.TAX_PERCENTAGE;
            int expectedStock = initialStock - transaction.Quantity;

            operation = new SellOperation(session);
            Assert.ThrowsException<OutOfStockException>(()=> operation.Execute(transaction));
        }
    }
}
