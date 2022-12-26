using SecuritySafeZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecuritySafeZone.Controllers
{
    public class LoginAdminController : Controller
    {
        SafeZoneEntities8 db = new SafeZoneEntities8();
        // GET: LoginAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminLogIn admin)
        {
            var ad = db.AdminLogIns.Where(Models => Models.Email == admin.Email && Models.Password == admin.Password).FirstOrDefault();
            if (ad != null)
            {
                Session["AdminId"] = admin.Aid.ToString();
                Session["Username"] = admin.Email.ToString();
                TempData["Login Message"] = admin.Email;
                TempData.Keep();
                return RedirectToAction("Dashboard");


            }
            else
            {
               
                ModelState.AddModelError("", "Email and Password is incorrect!");
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}