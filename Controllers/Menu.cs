﻿using Jamiat_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jamiat_web.Controllers
{
#pragma warning disable CS8604
    public class Menu : Controller
    {

        private readonly JamiatContext db;

        public Menu(JamiatContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = db.MenuMappingMaster.ToList();
            ViewBag.menuItems = db.Menus.ToList();
            return View();
        }

        public IActionResult AddMenu(string url, string name)
        {
            try
            {
                db.Menus.Add(new()
                {
                    Url = url,
                    Menu = name,
                    IsParent = true
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
            return Index();
        }


        public List<int> GetSelectedMenuIds(int masterId)
        {
            var list = db.MenuMappingMaster.Where(r => r.Id == masterId).Select(s => s.Id).ToList();
            return list;
        }

        [HttpPost]
        public string SaveMenu(List<int> selectedMenu, int masterId)
        {
            List<int> currentRoles = GetSelectedMenuIds(masterId);
            foreach (var id in currentRoles)
            {
                if (!selectedMenu.Contains(id))
                {
                    var menu = db.MenuMappings.Where(m => m.MasterId == id).FirstOrDefault();
                    db.MenuMappings.Remove(menu);
                }
            }
            foreach (var id in selectedMenu)
            {
                if (!currentRoles.Contains(id))
                {
                    db.MenuMappings.Add(new MenuMappings
                    {
                        MasterId = masterId,
                        MenuId = id,
                        EntryDate = DateTime.Now
                    });
                }
            }
            db.SaveChanges();
            return "success";
        }



        public List<Halqa> GetHalqas()
        {
            try
            {
                return db.Halqa.ToList();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return new List<Halqa>();
            }
        }

        public List<Ilaqa> GetIlaqas()
        {
            try
            {
                return db.Ilaqa.ToList();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return new List<Ilaqa>();
            }
        }

    }
}
