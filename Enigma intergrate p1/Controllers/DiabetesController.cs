using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Randima_final.Models;
using connect;

namespace Enigma_intergrate_p1.Controllers
{
    public class DiabetesController : ApiController
    {

        [HttpPost]

        //post method to Send deseases and get unique symptom to that desease

        public IHttpActionResult SendanotherSym(idnum idnum)
        {

            string item1;
            string item2;
          

            
            if (idnum.id1 == null)
            {
                item1 = "";
            }
            else
            {
                item1 = idnum.id1.ToString();
            }

            if (idnum.id2 == null)
            {
                item2 = "";
            }
            else
            {
                item2 = idnum.id2.ToString();
            }




            string query = "EXEC [dbo].[anotherSym]'" + item1 + "','" + item2 + "'";
        
            DataTable Names = connectionProvider.LoadSomething(query);
            List<idnum> items = new List<idnum>();

            foreach (DataRow item in Names.Rows)
            {
                idnum data = new idnum();
               
                    data.id1 = item["UniqueSymptom"].ToString();
                   
                
              
                items.Add(data);
            }

            return Ok(items);

        }



//        [HttpGet]



//        public IHttpActionResult LoadDiabetes()
//        {
//            string query = "EXEC  Diaebetes";

//            DataTable Names = connectionProvider.LoadSomething(query);

//            List<Doctor> users = new List<Doctor>();

//            foreach (DataRow user in Names.Rows)
//            {
//                Doctor dia = new Doctor();
//                dia.DoctorName = user["DoctorName"].ToString();


//                users.Add(dia);
//            }


//            return Ok(users);
//        }
    }
}

