﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eclinic.Models
{
    public class RegisterPharmacy
    {
        public string NID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PharmacyName { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}