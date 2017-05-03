using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eclinic.Models
{
    public class NormalUserPatient
    {
        public string NID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string DoctorID { get; set; }
        public string SystemAdminID { get; set; }
        public string HospitalID { get; set; }
    }
}