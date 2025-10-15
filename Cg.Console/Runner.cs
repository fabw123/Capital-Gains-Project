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
        public static List<string> Run(List<string> inputLines, GlobalSession globalSession)
        {
            var tradeOperations = new List<TradeOperation[]>();
            foreach (string inputLine in inputLines) 
            {
                tradeOperations.Add(JsonSerializer.Deserialize<TradeOperation[]>(inputLine) ?? []);
            }

            var results = new List<string>();
            foreach (var tradeOperation in tradeOperations)
            {
                try
                {
                    var service = new TradeService(tradeOperation);
                    var result = service.Execute();
                    results.Add(JsonSerializer.Serialize(result));
                    globalSession.Tries = 0;
                }
                catch (OutOfStockException ex)
                {
                    results.Add(ex.Message);
                    globalSession.Tries++;
                }
                catch (InvalidOperationException ex) 
                { 
                    results.Add(ex.Message);
                }
            }

            return results;

        }

        private static void BlockSession(GlobalSession globalSession) 
        {
            globalSession.Tries++;
        }
    }
}
