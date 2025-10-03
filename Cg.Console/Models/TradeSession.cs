namespace Cg.Console.Models
{
    public record TradeSession
    {
        public TradeSession()
        {
            Stock = 0;
            WeightAvaragePrice = 0;
            Losses = 0;
        }

        private decimal _weightAvaragePrice;

        public decimal WeightAvaragePrice
        {
            get { return _weightAvaragePrice; }
            set { _weightAvaragePrice = Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }

        public int Stock { get; set; }

        public decimal Losses { get; set; }

    }
}
