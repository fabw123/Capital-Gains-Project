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

        public int Stock { get; set; }

        public decimal WeightAvaragePrice { get; set; }

        public decimal Losses { get; set; }
    }
}
