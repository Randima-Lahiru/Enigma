using connect;
using Randima_final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enigma_intergrate_p1.Controllers
{
    public class Sypmtom2Controller : ApiController
    {

        [HttpPost]

        //send another symptom and execute correct desease

        public IHttpActionResult SendanotherSym(idnum idnum)
        {

            string item1;



            if (idnum.id1 == null)
            {
                item1 = "";
            }
            else
            {
                item1 = idnum.id1.ToString();
            }





            string query = "EXEC [dbo].[correctdis]'" + item1 + "'";

            DataTable Names = connectionProvider.LoadSomething(query);
            List<idnum> items = new List<idnum>();

            foreach (DataRow item in Names.Rows)
            {
                idnum data = new idnum();

                data.id1 = item["DiseaseName"].ToString();
              


                items.Add(data);
            }

            return Ok(items);

        }

     

        //load two desease

     

          
        

    }
}
