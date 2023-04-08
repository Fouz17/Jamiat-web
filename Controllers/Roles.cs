using Jamiat_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jamiat_web.Controllers
{
    public class Roles : Controller
    {
        private readonly JamiatContext db;

        public Roles(JamiatContext _db)
        {
            db = _db;
        }


        // GET: Roles
        public ActionResult AddRoles()
        {
            ViewBag.responsibilities = db.Responsibilities.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddRoles(string roleName, int respId, string level)
        {
            try
            {
                MenuMappingMaster master = new()
                {
                    RespLevel = level,
                    RespId = respId,
                    Name = roleName
                };
                db.MenuMappingMaster.Add(master);
                db.SaveChanges();
                //ViewBag.responsibilities = db.Responsibilities.ToList();
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Role Already Added";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("AddRoles", "Roles");
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
