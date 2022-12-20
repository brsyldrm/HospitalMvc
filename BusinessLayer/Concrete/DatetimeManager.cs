using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DatetimeManager
    {
        Repository<Datetime> repodate = new Repository<Datetime>();
        public List<Datetime> GetAllDatetime()
        {
            return repodate.List();
        }
        public List<Datetime> GetDateByDoctor(int id)
        {
            return repodate.List(x => x.DoctorID == id);
        }
        public List<Datetime> GetDateByPatient(int id)
        {
            return repodate.List(x => x.Patient.User.UserID == id);
        }
        public int DatetimeAdd(Datetime p)
        {
            
            return repodate.Insert(p);
        }
        public int DelDatetime(int p)
        {
            Datetime dt = repodate.Find(x=>x.DatetimeID== p);
            return repodate.Delete(dt);
        }
        public int DatetimeAddBL(Datetime p)
        {
            return repodate.Insert(p);
        }
    }
}
