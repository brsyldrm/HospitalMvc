using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Datetime> Datetimes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        

    }
}
