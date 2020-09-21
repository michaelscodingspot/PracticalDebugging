using AdvancedDebuggingTechniques.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdvancedDebuggingTechniques.Services
{
    internal class CurrencyConverter
    {
        internal static async Task<double> Convert(string price, Currency inputCurrency, Currency outputCurrency)
        {
            var exchangeRate = await GetExchangeRate(inputCurrency, outputCurrency);
            var pricenum = double.Parse(price);
            return pricenum * exchangeRate;
        }

        private static async Task<double> GetExchangeRate(Currency from, Currency to)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://api.exchangeratesapi.io/latest?base={to}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var exchangeRate = JsonConvert.DeserializeObject<ExchangeRateModel>(responseContent);
            switch (from)
            {
                case Currency.EURO:
                    return exchangeRate.rates.EUR;
                case Currency.GBP:
                    return exchangeRate.rates.GBP;
                case Currency.USD:
                default:
                    return exchangeRate.rates.USD;
            }

        }
    }
}