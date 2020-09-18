using System;

namespace PracticalDebuggingWeb.Controllers.Services
{
    internal class CurrencyService
    {
        internal static Currency GetCurrencyFromString(string convertCurrency)
        {
            var cur = Enum.Parse<Currency>(convertCurrency, true);
            return cur;
        }
    }
}