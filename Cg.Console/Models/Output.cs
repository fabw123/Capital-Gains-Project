using System.Text.Json.Serialization;

namespace Cg.Console.Models
{
    public record Output
    {
        public Output(decimal tax)
        {
            Tax = tax;
        }

        [JsonPropertyName("tax")]
        public decimal Tax { get; init; }

        public static Output Default => new(0);
    }
}
