using Cg.Console;
using Cg.Console.Models;
using Cg.Console.Utils;
using Cg.Tests.IntegrationTests.TestFiles;
using System.Text.Json;

namespace Cg.Tests.IntegrationTests
{

    [TestClass]
    public class ExerciseCasesTest
    {

        [TestMethod]
        [DataRow("case1")]
        [DataRow("case2")]
        [DataRow("case3")]
        [DataRow("case4")]
        [DataRow("case5")]
        [DataRow("case6")]
        [DataRow("case7")]
        [DataRow("case8")]
        [DataRow("case9")]
        public void EssencialCases_Succeed(string useCase)
        {
            var input = InputResources.ResourceManager.GetString(useCase);
            var output = OutputResources.ResourceManager.GetString(useCase);
            var expectedOutput = JsonSerializer.Deserialize<Output[]>(output);
            List<string> inputLines = [input];
            var result = Runner.Run(inputLines);

            var actualOutput = JsonSerializer.Deserialize<Output[]>(result.FirstOrDefault());
            Assert.IsNotNull(result);
            Assert.AreEqual(inputLines.Count, result.Count);
            Assert.AreEqual(expectedOutput.Length, actualOutput.Length);

            for (int i = 0; i < actualOutput.Length; i++)
            {
                Assert.AreEqual(expectedOutput[i].Tax, actualOutput[i].Tax);
            }
        }

        [TestMethod]
        public void MultipleCases_Succeed()
        {
            var inputCase1 = InputResources.ResourceManager.GetString("case1");
            var inputCase2 = InputResources.ResourceManager.GetString("case2");
            List<string> inputLines = [inputCase1, inputCase2];

            var result = Runner.Run(inputLines);

            Assert.IsNotNull(result);
            Assert.AreEqual(inputLines.Count, result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                var inputContent = JsonSerializer.Deserialize<Input[]>(inputLines[i]);
                var outputContent = JsonSerializer.Deserialize<Output[]>(result[i]);

                Assert.AreEqual(inputContent.Length, outputContent.Length);
            }

        }

        [TestMethod]
        public void MultipleExecutions_fail_StockOutOfStock()
        {
            var inputCase1 = InputResources.ResourceManager.GetString("case1");
            var inputContentCase1 = JsonSerializer.Deserialize<Input[]>(inputCase1);
            var inputOutOfStock = InputResources.ResourceManager.GetString("caseOutOfStock");
            List<string> inputLines = [inputCase1, inputOutOfStock];

            var result = Runner.Run(inputLines);
            var resultCase1Content = JsonSerializer.Deserialize<Output[]>(result[0]);

            Assert.IsNotNull(result);
            Assert.AreEqual(inputLines.Count, result.Count);
            Assert.AreEqual(inputContentCase1.Length, resultCase1Content.Length);
            Assert.AreEqual(ErrorMessages.NOT_ENOUGH_STOCK, result[1]);
        }

        [TestMethod]
        public void MultipleExecutions_fail_InvalidOperation()
        {
            var inputCase2 = InputResources.ResourceManager.GetString("case2");
            var inputContentCase1 = JsonSerializer.Deserialize<Input[]>(inputCase2);
            var inputInvalidOperation = InputResources.ResourceManager.GetString("caseInvalidOperation");
            List<string> inputLines = [inputCase2, inputInvalidOperation];

            var result = Runner.Run(inputLines);
            var resultCase1Content = JsonSerializer.Deserialize<Output[]>(result[0]);

            Assert.IsNotNull(result);
            Assert.AreEqual(inputLines.Count, result.Count);
            Assert.AreEqual(inputContentCase1.Length, resultCase1Content.Length);
            Assert.AreEqual(string.Format(ErrorMessages.INVALID_OPERATION, "change"), result[1]);
        }
    }
}
