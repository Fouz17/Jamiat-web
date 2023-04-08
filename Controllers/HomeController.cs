using Jamiat_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

#pragma warning disable CS8604
namespace Jamiat_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JamiatContext db = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Task<List<GetMenusResult>> result = db.GetProcedures().GetMenusAsync(int.Parse(HttpContext.Session.GetString("UserId")));

            return View(result);
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
    }
}