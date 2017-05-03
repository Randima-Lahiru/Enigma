using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using enigmaApp.Models;
using enigmaApp;
using System.Web.Services;
using connect;

namespace Enigma_intergrate_p1.Controllers
{
    public class PostDetailsController : ApiController
    {
     [HttpPost]
        public IHttpActionResult Date(Test date)
        {
            string d =date.Date;
            string e = date.DoctorID;
            string f = date.HospitalID;
            if (date.Date == null)
            {
                d = "";
            }
            else
            {
                d = date.Date.ToString();
            }
            if(date.DoctorID == null)
            {
                e = "";
            }
            else
            {
                e = date.DoctorID.ToString();
            }
             if(date.HospitalID == null)
            {
                f = "";
            }
            else
            {
                f= date.HospitalID.ToString();
            }

            string query = "EXEC [dbo].[Get_Time]'" + d +"','" + e+ "','" + f+"'";

            DataTable Times = connectionProvider.LoadSomething(query);
            List<Test> users = new List<Test>();

            foreach (DataRow user in Times.Rows)
            {
                Test h = new Test();
                h.TimeSlot = user["TimeSlot"].ToString();

                users.Add(h);

            }

            return Ok(users);
        }


    }
}
