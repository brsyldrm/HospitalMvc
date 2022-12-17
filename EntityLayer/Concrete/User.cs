using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(11)]
        public string TC { get; set; }
        [StringLength(20)]
        public string Passwd { get; set; }
        public int Rol { get; set; }
        public ICollection<Patient> Patients { get; set; }

    }
}
