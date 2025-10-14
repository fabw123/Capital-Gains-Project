using System.Text.Json.Serialization;

namespace Cg.Console.Models
{
    public record TaxResult
    {
        public TaxResult(decimal tax)
        {
            Tax = Math.Round(tax, 2, MidpointRounding.AwayFromZero);
        }

        [JsonPropertyName("tax")]
        public decimal Tax { get; init; }

        public static TaxResult Default => new(0);
    }
}
