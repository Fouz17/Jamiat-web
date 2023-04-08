using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Jamiat_web.Models;

#pragma warning disable CS8600
namespace Jamiat_web.Controllers
{
    public class Login : Controller
    {

        private readonly JamiatContext _context;

        public Login(JamiatContext context)
        {
            _context = context;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult LoginUser(string email, string password)
        {
            try
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                using MD5 md5 = MD5.Create();
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                password = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Users user = _context.Users.Where(x => x.Name == email && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("Index", "Home");
                }
                ViewData["LoginError"] = "Incorrect Username or password";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                ViewData["LoginError"] = e.Message;
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
