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
            try
            {
                int UserId = int.Parse(HttpContext.Session.GetString("UserId") ?? "0");
                string status = db.UserRespMapping.Where(x => x.UserId == UserId).Select(x => x.RespLevel).FirstOrDefault() ?? "";
                List<GetHalqaMembersResult> users = db.GetProcedures().GetHalqaMembersAsync(status).Result;
                ViewBag.Members = users;
            }
            catch (Exception e) {
                ViewBag.Members = new List<GetHalqaMembersResult>();
            }
            return View();
        }
    }
}
