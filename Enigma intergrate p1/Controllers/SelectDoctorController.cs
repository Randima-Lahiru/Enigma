using connect;
using enigmaApp;
using enigmaApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;

namespace Enigma.Controllers
{
    public class SelectDoctorController : ApiController
    {

        [HttpPost]
        public IHttpActionResult LoadHospital(Test Test)
        {
            string a = Test.DoctorID;
            int position = a.IndexOf(" ");
            string s = a.Substring(position + 1);
            int position2 = s.IndexOf(" ");
            string x = s.Substring(0, position2);
            string y = s.Substring(position2 + 1);
            if (x == null || y == null)
            {
                x = "";
                y = "";
                return Ok(x);
            }
            else
            {


                string query = "EXEC [dbo].[Load_Hospital]'" + x + "','" + y + "'EXEC [dbo].[report1]'"+ x +"','"+y+ "'";
                DataTable Names = connectionProvider.LoadSomething(query);
                List<Test> users = new List<Test>();

                foreach (DataRow user in Names.Rows)
                {
                    Test h = new Test();
                    h.HospitalID = user["HospitalName"].ToString();

                    users.Add(h);

                }


                return Ok(users);
            }



        }
    }
}