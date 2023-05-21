using Jamiat_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jamiat_web.Controllers
{
    public class HalqaManagement : Controller
    {
        private readonly JamiatContext db;
        public HalqaManagement(JamiatContext _db)
        {
            db = _db;
        }

        public IActionResult HalqaMembers()
        {
            int UserId = int.Parse(HttpContext.Session.GetString("UserId") ?? "0");
            string status = db.UserRespMapping.Where(x => x.UserId == UserId).Select(x => x.RespLevel).FirstOrDefault()??"";
            List<Users> users = db.Users.Where(x => x.Status == status && x.Id != UserId).ToList();
            ViewBag.Members = users;
            return View();
        }
    }
}
