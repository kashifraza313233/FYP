using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecuritySafeZone.Models;
namespace SecuritySafeZone.Controllers
{
    public class ReportIncidentController : Controller
    {
        // GET: ReportIncident
        SafeZoneEntities8 db = new SafeZoneEntities8();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReportSection(Report report)
        {

            Report report1 = new Report();
            if (ModelState.IsValid == true)
            {
                report1.Uid = (int)Session["Uid"];
                report1.Type = report.Type;
                report1.Description = report.Description;
                report1.Time = report.Time;
                report1.Date = report.Date;
                report1.Lat = report.Lat;
                report1.Lng = report.Lng;
                report1.Status = "Pending";
                report1.Address = report.Address;
                db.Reports.Add(report1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult ReportApproveSection(int id)
        {
            var report = db.Reports.FirstOrDefault(r => r.Rid == id);
            return View(report);
        }
        public ActionResult Reportlist()
        {

            return View(db.Reports.ToList());
        }
        public ActionResult Approve(int? Rid)
        {
            String boundaries = Request.Form["Boundary"];
            var report = db.Reports.Find(Rid);
            report.Pid = (int)Session["Pid"];
            report.Boundary = boundaries;
            report.Status = "Approve";
            db.Entry(report).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Reportlist", "ReportIncident");
        }
        public ActionResult Fake(int? Rid)
        {
            var report = db.Reports.Find(Rid);
            report.Pid = (int)Session["Pid"];
            report.Status = "Fake";
            db.Entry(report).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Reportlist", "ReportIncident");
        }
        public ActionResult Letsmovesafely()
        {
            var Listdata = db.Reports.ToList();
            string markers = "", first = "";
            string markersList = "";
            for (int i = 0; i < Listdata.Count; i++)
            {
                if (Listdata[i].Status == "Approve")
                {
                    var locations = Listdata[i].Boundary.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var location in locations)
                    {
                        var latLng = location.Replace("(", "").Replace(")", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        if (markers == "")
                            markers += "[";
                        else
                            markers += ",";

                        if (first == "")
                            first = "{" + string.Format("lat:{0},lng:{1}", latLng[0], latLng[1]) + "}";
                        markers += "{" + string.Format("lat:{0},lng:{1}", latLng[0], latLng[1]) + "}";

                    }
                    if (first != "")
                    {
                        markers += "," + first;
                        first = "";
                    }
                    if (markers != "")
                        markers += "]";
                }

                if (markersList != "")
                    markersList += ",";
                else
                    markersList += "[";

                if (markers != "")
                    markersList += markers;
                markers = "";
            }
            markersList += "]";
            //add status of the case in the view bag
            ViewBag.Markers = markersList;
            return View();
        }
    }
}