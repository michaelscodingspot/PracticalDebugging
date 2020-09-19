using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalDebuggingWeb.Services;
using PracticalDebuggingWeb.Models;
using Serilog;

namespace PracticalDebuggingWeb.Controllers
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
