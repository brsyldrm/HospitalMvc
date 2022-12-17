using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Patient
    {

        [Key]
        public int PatientID { get; set; }
        public virtual User User { get; set; }
        [StringLength(50)]
        public string PatientName { get; set; }
        public ICollection<Datetime> Datetimes { get; set; }
    }
}
