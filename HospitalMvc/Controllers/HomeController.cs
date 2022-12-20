using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using HospitalMvc.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalMvc.Models;
using System.Data.Entity.Core.Metadata.Edm;
using System.Security.Cryptography;
using DataAccessLayer.Concrete;
using Newtonsoft.Json;
using System.Web.Helpers;
using Antlr.Runtime.Misc;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Web.Security;

namespace HospitalMvc.Controllers
{
    public class HomeController : Controller
    {
        PatientManager pm = new PatientManager();
        DatetimeManager dtm= new DatetimeManager();
        BranchManager bm = new BranchManager();
        DoctorManager dm = new DoctorManager();
        HospitalDbEntities db = new HospitalDbEntities();
        HospitalDbEntities1 db2 = new HospitalDbEntities1();

        public ActionResult Doctor()
        {
            string p = (string)Session["UserID"];
            int pid = Convert.ToInt32(p);
            var Datelist = dtm.GetDateByDoctor(pid);
            return View(Datelist);
        }
        public PartialViewResult Doctor1()
        {
            TempData["Bugün"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            string p = (string)Session["UserID"];
            int pid = Convert.ToInt32(p);
            var DoctorName = dm.GetDoctorByUser(pid);
            return PartialView(DoctorName);
        }
        [HttpGet]
        public ActionResult Patient()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Doctors.ToList() select new SelectListItem { Text = x.DoctorName, Value = x.DoctorID.ToString() }).ToList();
            List<SelectListItem> values2 = (from x in c.Branchs.ToList() select new SelectListItem { Text = x.BranchName, Value = x.BranchID.ToString()}).ToList();
            ViewBag.values = values;
            ViewBag.values2 = values2;
            //doctorun id si alınırsa bir şeyler daha yapılabilir.
            return View();
        }
        [HttpPost]
        public ActionResult Patient(Datetime p)
        {
            string y = (string)Session["DoctorID"];
            PatientListVm vm = new PatientListVm((string)Session["UserID"]);
            Datetime pi = new Datetime()
            {
                PatientID = vm.user.PatientID,
                DoctorID = Convert.ToInt32(y),
                Time = p.Time
            };
            dtm.DatetimeAddBL(pi);
            return RedirectToAction("Patient");
        }
            
        public PartialViewResult PatientList()
        {

            PatientListVm vm =new PatientListVm((string)Session["UserID"]);
            TempData["Patient"] = vm.user.PatientName;
            TempData["Bugün"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string p = (string)Session["UserID"];
            int pid = Convert.ToInt32(p);
            var DateList = dtm.GetDateByPatient(pid);
            return PartialView(DateList);
        }
        public JsonResult doctorgetir(int p)
        {
            var doctors = (from x in db.Doctors
                           join y in db.Branches on x.BranchID equals y.BranchID
                           where x.BranchID == p
                           select new
                           {
                               Text = x.DoctorName,
                               Value = x.DoctorID.ToString()
                           }).ToList();
            return Json(doctors,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBusyDaysByDoctorId(int p)
        {
            var BusyDays = (from x in db2.Datetimes
                            where x.DoctorID == p
                            select new
                            {
                                Date = x.Time.ToString()
                            }).ToList();
            var result = new List<string>();
            for(int i = 1; i < 16; i++)
                {
                for (int j = 9; j < 17; j++)
                {
                    for (int x = 0; x < 46; x += 15)
                    {
                        var k =Convert.ToDateTime(DateTime.Now.ToString("dd / MM / yyyy")).AddDays(i).AddHours(j).AddMinutes(x);
                        for (int y =0;y<BusyDays.Count;y++)
                        {
                            DateTime hey = Convert.ToDateTime(BusyDays[y].Date);
                            if (hey != k)
                            {
                                if (y == 1) { break; }
                                else
                                {
                                    result.Add(k.ToString());
                                }
                            }
                        }
                    }
                }
            }
            string key = p.ToString();
            FormsAuthentication.SetAuthCookie(Convert.ToString(key), false);
            Session["DoctorID"] = Convert.ToString(key);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}