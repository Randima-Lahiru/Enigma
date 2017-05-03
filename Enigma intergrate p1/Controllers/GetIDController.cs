using connect;
using enigmaApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Randima_final.Controllers
{
    public class GetIDController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetID(Test id)
        {
            string s = id.PatientID;
            string query = "EXEC [dbo].[Get_ID]'" + s + "'";
            DataTable items = connectionProvider.LoadSomething(query);
            List<Test> users = new List<Test>();

            foreach (DataRow user in items.Rows)
            {
                Test i = new Test();
                i.ChannelingID = user["ChannelingID"].ToString();
                i.DoctorName = user["DoctorName"].ToString();
                i.HospitalName = user["HospitalName"].ToString();
                i.TimeSlot = user["TimeSlot"].ToString();
                i.Date = user["Date"].ToString();
                users.Add(i);

            }
            return Ok(users);
        }
    }
}
