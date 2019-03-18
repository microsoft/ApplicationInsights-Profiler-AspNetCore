using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppInsightsProfilerExample.Models;

namespace AppInsightsProfilerExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SimulateDelay();
            return View();
        }

        public IActionResult About()
        {
            SimulateDelay();
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            SimulateDelay();
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SimulateDelay()
        {
            // Delay for 500ms to 2s to simulate a bottleneck.
            Thread.Sleep((new Random()).Next(500, 2000));
        }
    }
}
