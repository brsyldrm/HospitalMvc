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

namespace HospitalMvc.Controllers
{
    public class HomeController : Controller
    {
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
            TempData["dis"] = "disabled";
            PatientAddDateVm vm = new PatientAddDateVm();
            vm.Branches = new SelectList(db.Branches, "BranchID", "BranchName");
            vm.Doctors = new SelectList(db.Doctors, "DoctorID", "DoctorName");
            vm.datetimes = dtm.GetAllDatetime();
            //doctorun id si alınırsa bir şeyler daha yapılabilir.
            return View(vm);
        }
        [HttpPost]
        public ActionResult Patient(Datetime p)
        {
            dtm.DatetimeAdd(p);
            return View();
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
                                date = x.Time.ToString(),
                            }).ToList();
            return Json(BusyDays, JsonRequestBehavior.AllowGet);
        }

    }
}