// See https://aka.ms/new-console-template for more information
using Cg.Console;
using Cg.Console.Models;
using System.Text.Json;

List <Input[]> inputs = [];
var inputString = Console.ReadLine();
while(!string.IsNullOrWhiteSpace(inputString))
{
    inputs.Add(JsonSerializer.Deserialize<Input[]>(inputString));
    inputString = Console.ReadLine();
}


List<List<Output>> results = [];
int stock =0;
decimal weightAvaragePrice = 0;
decimal tax = 20;
decimal looses = 0;

foreach (var transactions in inputs)
{
    List<Output> sessionResults = [];
    foreach (var transaction in transactions)
    {
        if (transaction.Operation == Operations.BUY)
        {
            weightAvaragePrice = ((stock * weightAvaragePrice) + (transaction.Quantity * transaction.UnitCost)) / (stock + transaction.Quantity);
            stock = stock + transaction.Quantity;
            sessionResults.Add(new Output(0));
        }

        if (transaction.Operation == Operations.SELL)
        {
            var totalAmount = (transaction.Quantity * transaction.UnitCost);
            var totalProfit = (totalAmount - (transaction.Quantity * weightAvaragePrice));

            if (totalProfit < 0)
            {
                looses = looses + totalProfit;
                sessionResults.Add(new Output(0));
            }
            else if (totalAmount > 20000)
            {
                if (looses < 0)
                {
                    totalProfit = totalProfit + looses;
                }

                if (totalProfit > 0)
                {
                    sessionResults.Add(new Output(totalProfit * (tax / 100)));
                    looses = 0;
                }
                else
                {
                    sessionResults.Add(new Output(0));
                    looses = totalProfit;
                }


            }
            else
            {
                sessionResults.Add(new Output(0));
            }

            stock = stock - transaction.Quantity;

        }
    }

    results.Add(sessionResults);
}


foreach (var result in results)
{
    Console.WriteLine(JsonSerializer.Serialize(result));
}


