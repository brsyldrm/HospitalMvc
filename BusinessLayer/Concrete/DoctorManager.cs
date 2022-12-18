using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DoctorManager
    {
        Repository<Doctor> repodoctor = new Repository<Doctor>();
        public List<Doctor> GetAllDoctors()
        {
            return repodoctor.List();
        }
        public List<Doctor> GetDoctorByBranch(int id)
        {
            return repodoctor.List(x=>x.BranchID== id);
        }
        public List<Doctor> GetDoctorByUser(int id)
        {
            return repodoctor.List(x=>x.User.UserID== id);
        }
    }
}
