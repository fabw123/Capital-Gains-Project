// See https://aka.ms/new-console-template for more information
using Cg.Console;
using Cg.Console.Models;


GlobalSession globalSession = new();
while (!globalSession.Blocked)
{

    List<string> inputLines = [];
    var inputLine = Console.ReadLine();
    while (!string.IsNullOrWhiteSpace(inputLine))
    {
        inputLines.Add(inputLine);
        inputLine = Console.ReadLine();
    }

    var result = Runner.Run(inputLines, globalSession);
    foreach (var output in result)
    {
        Console.WriteLine(output);
    }
}

if (globalSession.Blocked)
{
    Console.WriteLine("Session blocked after too many errors.");
    Console.ReadKey();
}




