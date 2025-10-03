using Cg.Console.Exceptions;
using Cg.Console.Models;
using Cg.Console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cg.Console
{
    public class Runner
    {
        public static List<string> Run(List<string> inputLines)
        {
            var inputs = new List<Input[]>();
            foreach (string inputLine in inputLines) 
            {
                inputs.Add(JsonSerializer.Deserialize<Input[]>(inputLine) ?? []);
            }

            var results = new List<string>();
            foreach (var transactions in inputs)
            {
                try
                {
                    var service = new TransactionService(transactions);
                    var result = service.Execute();
                    results.Add(JsonSerializer.Serialize(result));
                }
                catch (OutOfStockException ex)
                {
                    results.Add(ex.Message);
                }
                catch (InvalidOperationException ex) 
                { 
                    results.Add(ex.Message);
                }
            }

            return results;

        }
    }
}
