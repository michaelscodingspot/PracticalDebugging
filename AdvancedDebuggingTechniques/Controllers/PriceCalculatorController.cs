using AdvancedDebuggingTechniques.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvancedDebuggingTechniques.Controllers
{
    public class PriceCalculatorController : Controller
    {
        public async Task<IActionResult> Calculate(string price, string inputCurrency, string outputCurrency, string couponCode, string discount)
        {
            var result = await new PriceCalculator().Calculate(price, inputCurrency, outputCurrency, couponCode, discount);
            return View("Result", result);
        }



    }
}
