using Jamiat_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

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
        public IActionResult Add(Users obj)
        {
            try
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(obj.Password);
                using MD5 md5 = MD5.Create();
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                obj.Password = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                db.Users.Add(obj);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Index();
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
