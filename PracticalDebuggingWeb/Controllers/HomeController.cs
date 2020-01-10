using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalDebuggingWeb.Models;
using Serilog;

namespace PracticalDebuggingWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Log.Information("Home/Index");
            return View();
        }

        public async Task<IActionResult> LongRunning()
        {
            await Task.Delay(45000);
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Crash()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Thread.Sleep(1500);
                throw new Exception("Let's crash this party");
            });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
