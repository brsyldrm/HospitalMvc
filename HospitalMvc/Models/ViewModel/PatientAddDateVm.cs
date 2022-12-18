using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalMvc.Models.ViewModel
{
    public class PatientAddDateVm
    {
        public IEnumerable<SelectListItem> Branches { get; set; }
        public IEnumerable<SelectListItem> Doctors{ get; set; }
        public IEnumerable<Datetime> datetimes { get; set; }
        
}
}