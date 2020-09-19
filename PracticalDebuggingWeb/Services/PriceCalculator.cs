using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingWeb.Services
{
    public class PriceCalculator
    {

        public async Task<double> Calculate(string price, string inputCurrencyStr, string outputCurrencyStr, string couponCode, string discount)
        {
            var inputCurrency = CurrencyService.GetCurrencyFromString(inputCurrencyStr);
            var outputCurrency = CurrencyService.GetCurrencyFromString(outputCurrencyStr);
            double priceResult;
            if (inputCurrency == outputCurrency)
            {
                priceResult = double.Parse(price);
            }
            else
            {
                priceResult = await CurrencyConverter.Convert(price, inputCurrency, outputCurrency);
            }

            if (!string.IsNullOrEmpty(couponCode))
            {
                double couponDiscountPercent = CouponService.GetCouponDiscount(couponCode);
                var couponDiscount = GetDiscount(couponDiscountPercent, priceResult);
                priceResult -= couponDiscount;
            }
            if (discount != null)
            {
                var discountNum = GetDiscount(double.Parse(discount), priceResult);
                priceResult -= discountNum;
            }
            return priceResult;
        }

        private double GetDiscount(double discount, double price)
        {
            return discount / 100.0 * price;
        }
    }
}
