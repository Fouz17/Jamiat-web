using Microsoft.AspNetCore.Mvc;

namespace Jamiat_web.Controllers
{
    public class Reporting : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult HalqaReport()
        {
            return View();
        }

    }
}
