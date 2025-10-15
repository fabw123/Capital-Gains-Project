using System.Text.Json.Serialization;

namespace Cg.Console.Models
{
    public record TradeOperation
    {
        public TradeOperation(string operation, decimal unitCost, int quantity, StockType type)
        {
            Operation = operation;
            UnitCost = unitCost;
            Quantity = quantity;
            Type = type;
        }

        [JsonPropertyName("operation")]
        public string Operation { get; init; }

        [JsonPropertyName("unit-cost")]
        public decimal UnitCost { get; init; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; init; }

        [JsonPropertyName("type")]
        public StockType Type { get; set; }
    }
        
}
