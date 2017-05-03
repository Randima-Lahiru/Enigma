using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eclinic.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}