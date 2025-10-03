using System.Diagnostics.CodeAnalysis;

namespace Cg.Console.Utils
{

    [ExcludeFromCodeCoverage]
    public static class GeneralConfiguration
    {
        public const string OPERATION_BUY = "buy";

        public const string OPERATION_SELL = "sell";

        public const decimal TAX = 20;
        public static decimal TAX_PERCENTAGE => TAX/100;

        public const decimal TAX_EXCEPTION_LIMIT = 20000;
    }
}
