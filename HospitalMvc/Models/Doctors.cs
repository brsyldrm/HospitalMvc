//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctors
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int BranchID { get; set; }
        public Nullable<int> User_UserID { get; set; }
    
        public virtual Branches Branches { get; set; }
    }
}
