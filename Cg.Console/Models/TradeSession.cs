namespace Cg.Console.Models
{
    public record TradeSession
    {
        public TradeSession()
        {
            Stock = new()
            {
                {StockType.TypeA, 0 },
                {StockType.TypeB, 0 },
                {StockType.TypeC, 0 },
                {StockType.Undefined, 0 },
            };
            WeightAvaragePrice = 0;
            Losses = 0;
        }

        private decimal _weightAvaragePrice;

        public decimal WeightAvaragePrice
        {
            get { return _weightAvaragePrice; }
            set { _weightAvaragePrice = Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }

        public Dictionary<StockType, int> Stock { get; set; }

        public decimal Losses { get; set; }

    }

    public class Stock
    {
        public StockType Type { get; set; }
        public int Quantity { get; set; }
    }
}
