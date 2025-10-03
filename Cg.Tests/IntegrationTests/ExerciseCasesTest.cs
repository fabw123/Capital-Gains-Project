using Cg.Console;
using Cg.Console.Models;
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
            var outputCase1 = OutputResources.ResourceManager.GetString("case1");
            var outputCase2 = OutputResources.ResourceManager.GetString("case2");
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
    }
}
