namespace Cg.Console.Models
{
    public record Output(decimal Tax)
    {
        public static Output Default => new(0);
    }
}
