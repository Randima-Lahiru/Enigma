using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using connect;
using Eclinic.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Text;

namespace Enigma_intergrate_p1.Controllers
{
    public class PatientRegistrationController : ApiController
    {


        [HttpPost]
        public IHttpActionResult RegisterPatient(NormalUserPatient patient)
        {

            string first = patient.FName;
            string last = patient.LName;
            string uname = patient.UserName;
            string password = patient.Password;
            string address = patient.Address;
            string bloodgroup = patient.BloodGroup;
            string gender = patient.Gender;
            string age = patient.Age;
            string NewID;
            int temp;

            using (SqlConnection conn = new SqlConnection())

            {
                conn.ConnectionString = "Data Source=DESKTOP-3SOIUD0\\SQLEXPRESS;Initial Catalog=Eclinic;Integrated Security=True";
                conn.Open();
                string query1 = "EXEC Load_PatientID";
                SqlCommand LastID = new SqlCommand(query1, conn);
                string LID = LastID.ExecuteScalar().ToString().Replace(" ", "");
                conn.Close();
                conn.Open();
                string checkuname = "select count(*) from NormalUser where UserName = '" + uname + "'";
                SqlCommand com = new SqlCommand(checkuname, conn);
                temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();


                int position = LID.IndexOf("t");
                string Spart = "Pat";
                string ID = LID.Substring(position + 1);
                int IDval = Int32.Parse(ID);
                int Nid = ++IDval;
                string Ipart = Nid.ToString();
                NewID = string.Concat(Spart, Ipart);
            }
            if (temp == 0)
            {
                string query = "EXEC Add_PatientDetails'" + NewID + "','" + bloodgroup + "','" + gender + "','" + age + "'EXEC Add_UserDetailsOfPatient'" + NewID + "','" + first + "','" + last + "','" + address + "','" + uname + "','" + password + "'";
                int result = connectionProvider.CreateSomething(query);
                return Ok(result);
            }
            else
            {
                testenigma mal = new testenigma();
                mal.test1 = temp.ToString();
                return Ok(mal);
            }

        }
    }
}