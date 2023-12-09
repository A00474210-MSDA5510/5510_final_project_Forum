using _5510_final_project_Forum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace _5510_final_project_Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        public IActionResult ValidatePostalCode([Bind(Prefix = "Input.PostalCode")] String PostalCode, [Bind(Prefix = "Input.Country")] String Country)
        {
            if (Country.Equals("USA"))
            {
                if (!Regex.Match(PostalCode, @"^\d{5}(-\d{4})?$").Success)
                    return Json($"Invalid USA Postal Code");
            }
            else if (Country.Equals("Canada"))
            {
                if (!Regex.Match(PostalCode, @"[A-Z]\d[A-Z]\s{0,1}\d[A-Z]\d").Success)
                    return Json($"Invalid Canada Postal Code");
            }
            return Json(true);
        }
    }
}