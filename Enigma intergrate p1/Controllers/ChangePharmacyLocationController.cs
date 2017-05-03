using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eclinic.Models;
using connect;

namespace Eclinic.Controllers
{
    public class ChangePharmacyLocationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ChangePharmacyLocation(RegisterPharmacy changelocation)
        {
            string ID = changelocation.NID;
            string Address = changelocation.Address;
            string Lat = changelocation.Lat;
            string Long = changelocation.Long;

            string query = "EXEC Change_PharmacyLocation '" + Lat + "','" + Long + "','" + Address + "','" + ID + "'";
            int i = connectionProvider.CreateSomething(query);

            return Ok(i);
        }
    }
}
