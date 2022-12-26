using SecuritySafeZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecuritySafeZone.Controllers
{
    public class PoliceSignupController : Controller
    {
        
        SafeZoneEntities8 db = new SafeZoneEntities8();
        // GET: PoliceSignup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Police p)
        {
            var pol = db.Police.Where(model => model.Email == p.Email && model.Password == p.Password).FirstOrDefault();
            if (pol != null)
            {
               if(pol.status==1)
                {
                    Session["UserId"] = p.Pid.ToString();
                    Session["username"] = p.Email.ToString();
                    TempData["LoginSuccessMessage"] = p.Email;
                    TempData.Keep();
                    return RedirectToAction("DashboardPolice", "PoliceSignup");
                }
                else if (pol.status == 0)
                {
                    ModelState.AddModelError("", "Your Account is Not Approve");
                }
                else
                {
                    ModelState.AddModelError("", "Your Email & Password is Incorrect!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Email and Password is incorrect!");
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Police police)
        {
            if (ModelState.IsValid == true)
            {
                db.Police.Add(police);

                int a = db.SaveChanges();
                if (a > 0)
                {
                   
                    return RedirectToAction("Index", "PoliceSignup");

                }
                else
                {
                    ModelState.AddModelError("", "Registeration Failed!");
                }
            }
            return View();

        }
        public ActionResult Policelist()
        {
            return View(db.Police.ToList());
        }
        public ActionResult Approve(int? pid)
        {
            var police = db.Police.Find(pid);
            police.status = 1;
            db.Entry(police).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dashboard", "LoginAdmin");
        }
        public ActionResult Dissmiss(int? pid)
        {
            var police = db.Police.Find(pid);
            police.status = 0;
            db.Entry(police).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dashboard", "LoginAdmin");
        }
        public ActionResult DashboardPolice()
        {
            return View();
        }
    }
}