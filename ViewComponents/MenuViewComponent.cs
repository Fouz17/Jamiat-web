using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jamiat_web.Models;
using System;

namespace Jamiat_web.ViewComponents
{
    [ViewComponent(Name = "MenuBar")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly JamiatContext db;

        public MenuViewComponent(JamiatContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //List<Menubar> menuItems = new List<Menubar>();
            List<GetMenusResult> menuItems = new List<GetMenusResult>();

            try
            {

                var userId = int.Parse(HttpContext.Session.GetString("UserId") ?? "0");

                menuItems = await db.GetProcedures().GetMenusAsync(userId);

                Console.WriteLine(menuItems);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ViewBag.MenuItems = menuItems;
            return View("MenuBar");

        }



    }
}
