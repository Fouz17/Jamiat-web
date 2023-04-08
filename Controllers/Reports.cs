using Jamiat_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jamiat_web.Controllers
{
    public class Reports : Controller
    {
        private readonly JamiatContext db;
        public Reports(JamiatContext _db)
        {
            db = _db;
        }

        public IActionResult Shaheens()
        {
            return View();
        }

        public IActionResult Rufqa()
        {
            return View();
        }

        public IActionResult Ilaqa()
        {
            return View();
        }
    }
}
