using System.Text.Json.Serialization;

namespace Cg.Console.Models
{
    public record Input
    {
        public Input(string operation, decimal unitCost, int quantity)
        {
            Operation = operation;
            UnitCost = unitCost;
            Quantity = quantity;
        }

        [JsonPropertyName("operation")]
        public string Operation { get; init; }

        [JsonPropertyName("unit-cost")]
        public decimal UnitCost { get; init; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; init; }
    }
        
}
