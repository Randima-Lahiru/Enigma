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
    public class SymptomController : ApiController
    {
        [HttpPost]

        //post method to send symptoms and get dsease
        public IHttpActionResult SendSym(idnum idnum)
        {

            string item1;
            string item2;
            string item3;
            string item4;

            {
            }
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
            if (idnum.id3 == null)
            {
                item3 = "";
            }
            else
            {
                item3 = idnum.id3.ToString();
            }
            if (idnum.id4 == null)
            {
                item4 = "";
            }
            else
            {
                item4 = idnum.id4.ToString();
            }

            
            string query = "EXEC [dbo].[Diseasesp1]'" + item1 + "','" + item2 + "','" + item3 + "','" + item4 + "'";
            
            DataTable Names = connectionProvider.LoadSomething(query);
            List<idnum> items = new List<idnum>();

            foreach (DataRow item in Names.Rows)
            {
                idnum data = new idnum();
                if (item.ItemArray.Length == 2)
                {
                    data.id1 = item["DiseaseName"].ToString();
                    data.id2 = item["DiseaseName"].ToString();
                }
                else
                {
                    data.id1 = item["DiseaseName"].ToString();
                }

               
                items.Add(data);
            }

            return Ok(items);

        }


        [HttpGet]


         //get method to get symptoms


        public IHttpActionResult LoadSymptom()
        {
            string query = "EXEC  Symptomsp1";

            DataTable Names = connectionProvider.LoadSomething(query);

            List<Symptom> users = new List<Symptom>();

            foreach (DataRow user in Names.Rows)
            {
                Symptom sym = new Symptom();
                sym.SymptomName = user["SymptomName"].ToString();


                users.Add(sym);
            }


            return Ok(users);
        }


    


    }

}

