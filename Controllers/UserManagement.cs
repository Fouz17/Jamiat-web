using Jamiat_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jamiat_web.Controllers
{
    public class UserManagement : Controller
    {
        private readonly JamiatContext db;
        public UserManagement(JamiatContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            var id = int.Parse(HttpContext.Session.GetString("UserId") ?? "3");
            var mapping = db.UserRespMapping.Where(x => x.UserId == id).FirstOrDefault();
            TempData["status"] = mapping?.RespLevel;
            ViewBag.Associations = db.Associations.ToList();
            return View();
        }

        [HttpPost]
        public Users Add(Users obj)
        {
            return new();
        }

        public ActionResult AddShaheen()
        {
            var id = int.Parse(HttpContext.Session.GetString("UserId") ?? "3");
            var mapping = db.UserRespMapping.Where(x => x.UserId == id).FirstOrDefault();
            TempData["status"] = mapping?.RespLevel;
            return View();
        }
    }
}
