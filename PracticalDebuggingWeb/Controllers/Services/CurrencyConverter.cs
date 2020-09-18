using System;
using System.Net.Http;

namespace PracticalDebuggingWeb.Controllers.Services
{
    internal class CurrencyConverter
    {
        internal static double ConvertToUsd(string price, Currency currency)
        {
            var exchangeRate = GetExchangeRate(currency, Currency.USD);
            var pricenum = double.Parse(price);
            return pricenum * exchangeRate;
        }

        private static double GetExchangeRate(Currency from, Currency to)
        {
            var httpClient = new HttpClient();
            //TODO: Go to https://exchangeratesapi.io/
            throw new NotImplementedException();
        }
    }
}