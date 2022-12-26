using SecuritySafeZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecuritySafeZone.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        SafeZoneEntities8 db = new SafeZoneEntities8();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            var use= db.Users.Where(model => model.Email == user.Email && model.Password == user.Password).ToList();
            if(use.Count!=0 )
            {
                if (use[0].status == 1)
                {
                    Session["UserId"] = use[0].Uid;
                    Session["username"] = use[0].Email.ToString();
                    TempData["LoginSuccessMessage"] = user.Email;
                    TempData.Keep();

                    return RedirectToAction("UserDashboard", "Login");
                }
                else if (use[0].status == 0)
                {
                    ModelState.AddModelError("", "Your Account is Not Approve");
                }
                else
                {
                    ModelState.AddModelError("", "Your Email & Password is Incorrect!");
                }
            }
            else if(user==null)
            {
                ModelState.AddModelError("", "No such Account Exist!");
            }
            
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult verifymsg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid == true)
            {
              //U
                User u = new User();
                u.Username=user.Username;
                u.CNIC = user.CNIC;
                u.Email = user.Email;
                u.ContactNo = user.ContactNo;
                u.Password = user.Password;
                u.status = 0;
                db.Users.Add(u);
                db.SaveChanges();
                TempData["User"] = u.Email;
                TempData.Keep();
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Registeration Failed! ");
            }
            return View();
        }
        public ActionResult userlist()
        {
            return View(db.Users.ToList());
        }
        public ActionResult Approve(int? uid)
        {
            var police = db.Users.Find(uid);
            police.status = 1;
            db.Entry(police).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dashboard", "LoginAdmin");
        }
        public ActionResult Dissmiss(int? uid)
        {
            var police = db.Users.Find(uid);
            police.status = 0;
            db.Entry(police).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dashboard", "LoginAdmin");
        }
        public ActionResult UserDashboard()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FB(Feedback  feedback)
        {
            if(ModelState.IsValid==true)
            {
                Feedback feedback1 = new Feedback();
                feedback1.Message = feedback.Message;
                feedback1.Email = feedback.Email;

                return RedirectToAction("Feedback");
               
            }
            else
            {
                ModelState.AddModelError("", "Feedback Not Send");
            }
            return View();
        }
        public ActionResult Movesafely()
        {
            return View();
        }
    }
}