using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalDebuggingWeb.Controllers.Services;
using PracticalDebuggingWeb.Models;
using Serilog;

namespace PracticalDebuggingWeb.Controllers
{
    public class PriceCalculatorController : Controller
    {
        public async Task<IActionResult> Calculate(string price, string convertCurrency, string couponCode, string discount)
        {
            var result = await new PriceCalculator().Calculate(price, convertCurrency, couponCode, discount);
            return View("Result", result);
        }



    }
}
