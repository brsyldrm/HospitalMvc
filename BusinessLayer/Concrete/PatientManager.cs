using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PatientManager
    {

        Repository<Patient> repopatient = new Repository<Patient>();
        public List<Patient> GetPatientByUser(int id)
        {
            return repopatient.List(x => x.User.UserID == id);
        }
    }
}
