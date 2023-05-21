using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Jamiat_web.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
                    HttpContext.Session.SetString("Status", user.Status);
                    Authenticate();
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

        private string Authenticate()
        {
            var tokenExpityTimestamp = DateTime.Now.AddMinutes(300);
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("Hassan.Co_436464454");
            var securityTokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("Auth","USER")
                }),
                Expires = tokenExpityTimestamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var securityToken = jwtSecurityHandler.CreateToken(securityTokenDescripter);
            var token = jwtSecurityHandler.WriteToken(securityToken);
            return token;
        }
    }
}
