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

namespace HospitalMvc.Controllers
{
    public class HomeController : Controller
    {
        DatetimeManager dtm= new DatetimeManager();
        BranchManager bm = new BranchManager();
        DoctorManager dm = new DoctorManager();
        HospitalDbEntities db = new HospitalDbEntities();

        public ActionResult Doctor()
        {
            string p = (string)Session["UserID"];
            int pid = Convert.ToInt32(p);
            var Datelist = dtm.GetDateByDoctor(pid);
            return View(Datelist);
        }
        public PartialViewResult Doctor1()
        {
            string p = (string)Session["UserID"];
            int pid = Convert.ToInt32(p);
            var DoctorName = dm.GetDoctorByUser(pid);
            return PartialView(DoctorName);
        }
        public ActionResult Patient()
        {
            PatientAddDateVm vm = new PatientAddDateVm();
            vm.Branches = new SelectList(db.Branches, "BranchID", "BranchName");
            vm.Doctors = new SelectList(db.Doctors, "DoctorID", "DoctorName");
            return View(vm);
        }
        public PartialViewResult PatientList()
        {
            string p = (string)Session["UserID"];
            int pid = Convert.ToInt32(p);
            var Datelist = dtm.GetDateByPatient(pid);
            return PartialView(Datelist);
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
        
    }
}