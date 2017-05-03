using System;
using enigmaApp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using enigmaApp.Models;
using System.Data;
using System.Web.Services;

using connect;

namespace Enigma_intergrate_p1.Controllers
{
    public class UpdateController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Update(Test update)
        {
            string a = update.Date;
            string b = update.DoctorID;
            string c = update.HospitalID;
            string d = update.TimeSlot;
            if (update.Date == null)
            {
                a = "";
            }
            else
            {
                a = update.Date.ToString();
            }
            if (update.DoctorID == null)
            {
                b = "";
            }
            else
            {
                b = update.DoctorID.ToString();
            }
            if (update.HospitalID == null)
            {
                c = "";
            }
            else
            {
                c = update.HospitalID.ToString();
            }
            if (update.TimeSlot == null)
            {
                d = "";
            }
            else
            {
                d = update.TimeSlot.ToString();
            }
            
            string query = "EXEC [dbo].[Update_Table]'" + a + "','" + b + "','" + c + "','" + d + "'";
            int result = connectionProvider.CreateSomething(query);
            return Ok(result);

        }
    }
}
    

