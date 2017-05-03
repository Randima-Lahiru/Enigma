
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using connect;

namespace Enigma_intergrate_p1.Controllers
{
    public class PharmacySearchController : ApiController
    {
        [HttpGet]
        public IHttpActionResult PharmacySearch(Pharmacy pharmacy)
        {
            string query = "EXEC Load_PharmacyLocation";
            DataTable location = connectionProvider.LoadSomething(query);

            List<Pharmacy> places = new List<Pharmacy>();

            foreach (DataRow place in location.Rows)
            {
                Pharmacy Pha = new Pharmacy();
                Pha.Lat = place["Lat"].ToString();
                Pha.Long = place["Long"].ToString();

                places.Add(Pha);
            }

            return Ok(places);
        }
    }
}
