// See https://aka.ms/new-console-template for more information
using Cg.Console.Models;
using Cg.Console.Services;
using System.Text.Json;

List <Input[]> inputs = [];
var inputString = Console.ReadLine();
while(!string.IsNullOrWhiteSpace(inputString))
{
    inputs.Add(JsonSerializer.Deserialize<Input[]>(inputString) ?? []);
    inputString = Console.ReadLine();
}


List<List<Output>> results = [];
TransactionService transactionService;

foreach (var transactions in inputs)
{
    transactionService = new(transactions);
    var sessionResults = transactionService.Execute();
    results.Add(sessionResults);
}

foreach (var result in results)
{
    Console.WriteLine(JsonSerializer.Serialize(result));
}


