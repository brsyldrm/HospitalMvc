using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Datetime
    {
        [Key]
        public int DatetimeID { get; set; }
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }
        public DateTime Time { get; set; }
    }
}
