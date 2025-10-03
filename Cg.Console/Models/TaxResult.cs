using System.Text.Json.Serialization;

namespace Cg.Console.Models
{
    public record TaxResult
    {
        public TaxResult(decimal tax)
        {
            Tax = tax;
        }

        [JsonPropertyName("tax")]
        public decimal Tax { get; init; }

        public static TaxResult Default => new(0);
    }
}
