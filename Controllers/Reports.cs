using Microsoft.AspNetCore.Mvc;

namespace Jamiat_web.Controllers
{
    public class Reports : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
