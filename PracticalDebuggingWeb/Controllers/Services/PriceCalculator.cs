using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingWeb.Controllers.Services
{


    public class PriceCalculator
    {

        public async Task<double> Calculate(string price, string convertCurrency, string couponCode, string discount)
        {
            var currency = CurrencyService.GetCurrencyFromString(convertCurrency);
            double priceUsd;
            if (currency == Currency.USD)
            {
                priceUsd = double.Parse(price);
            }
            else
            {
                priceUsd = CurrencyConverter.ConvertToUsd(price, currency);
            }

            if (!string.IsNullOrEmpty(couponCode))
            {
                double couponDiscountPercent = CouponService.GetCouponDiscount(couponCode);
                var couponDiscount = GetDiscount(couponDiscountPercent, priceUsd);
                priceUsd -= couponDiscount;
            }

            var discountNum = GetDiscount(double.Parse(discount), priceUsd);
            return priceUsd - discountNum;
        }

        private double GetDiscount(double discount, double price)
        {
            return discount / 100.0 * price;
        }
    }
}
