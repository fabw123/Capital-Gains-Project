// See https://aka.ms/new-console-template for more information
using Cg.Console;
using Cg.Console.Models;
using Cg.Console.Services;
using System.Text.Json;

List <string> inputLines = [];
var inputLine = Console.ReadLine();
while(!string.IsNullOrWhiteSpace(inputLine))
{
    inputLines.Add(inputLine);
    inputLine = Console.ReadLine();
}

var result = Runner.Run(inputLines);

foreach(var output in result)
{
    Console.WriteLine(output);
}


