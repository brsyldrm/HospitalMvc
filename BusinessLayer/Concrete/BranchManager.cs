using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BranchManager
    {
        Repository<Branch> repobranch = new Repository<Branch>();

        public List<Branch> GetAll()
        {
            return repobranch.List();
        }
    }
}
