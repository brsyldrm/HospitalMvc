using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        public virtual User User { get; set; }
        [StringLength(50)]
        public string DoctorName { get; set; }
        public int BranchID { get; set;}
        public virtual Branch Branch { get; set; }
        public ICollection<Datetime> Datetimes { get; set; }
    }
}
