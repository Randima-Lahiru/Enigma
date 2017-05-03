using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eclinic;

using System.Web.Services;
using connect;

namespace Enigma_intergrate_p1.Controllers
{
    public class DoctorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LoadHospital()
        {
            string query = "EXEC Select_Hospital";
            DataTable Names = connectionProvider.LoadSomething(query);
            List<AdminUser> users = new List<AdminUser>();
            foreach (DataRow user in Names.Rows)
            {
                AdminUser a = new AdminUser();
                a.Username = user["Username"].ToString();
                users.Add(a);
            }

            return Ok(users);
        }
    }
}
