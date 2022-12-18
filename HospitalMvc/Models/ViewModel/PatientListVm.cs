using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMvc.Models.ViewModel
{
    public class PatientListVm
    {
        public List<Datetime> datetimes { get; set; }
        public Patient user { get; set; }
        public PatientListVm(string id)
        {
            PatientManager pm= new PatientManager();
            this.user = pm.GetPatientByUser(Convert.ToInt32(id)).FirstOrDefault();
        }
    }
}