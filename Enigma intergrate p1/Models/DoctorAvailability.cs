using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eclinic.Models
{
    public class DoctorAvailability
    {
        public string ID { get; set; }
        public string Hospital { get; set; }
        public string Sday { get; set; }
        public string Eday { get; set; }
        public string Mon { get; set; }
        public string MStime { get; set; }
        public string MEtime { get; set; }
        public string Tue { get; set; }
        public string TStime { get; set; }
        public string TEtime { get; set; }
        public string Wed { get; set; }
        public string WStime { get; set; }
        public string WEtime { get; set; }
        public string Thu { get; set; }
        public string THStime { get; set; }
        public string THEtime { get; set; }
        public string Fri { get; set; }
        public string FStime { get; set; }
        public string FEtime { get; set; }
        public string Sat { get; set; }
        public string SAStime { get; set; }
        public string SAEtime { get; set; }
        public string Sun { get; set; }
        public string SUStime { get; set; }
        public string SUEtime { get; set; }
    }
}