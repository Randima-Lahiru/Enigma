using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eclinic.Models;
using System.Data.SqlClient;
using connect;

namespace Enigma_intergrate_p1.Controllers
{
    public class DoctorRegistrationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult DoctorRegistration(DoctorAll doctor)
        {
            string first = doctor.FName;
            string last = doctor.LName;
            string uname = doctor.UserName;
            string password = doctor.Password;
            string address = doctor.Address;
            string speciality = doctor.Speciality;
            string gender = doctor.Gender;
            string PNO = doctor.TelNo1;
            string NewID;
            int temp;

            using (SqlConnection conn = new SqlConnection())

            {
                conn.ConnectionString = "Data Source=DESKTOP-3SOIUD0\\SQLEXPRESS;Initial Catalog=Eclinic;Integrated Security=True";
                conn.Open();
                string query1 = "EXEC Load_DoctorID";
                SqlCommand LastID = new SqlCommand(query1, conn);
                string LID = LastID.ExecuteScalar().ToString().Replace(" ", "");
                conn.Close();
                conn.Open();
                string checkuname = "select count(*) from NormalUser where UserName = '" + uname + "'";
                SqlCommand com = new SqlCommand(checkuname, conn);
                temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();


                int position = LID.IndexOf("c");
                string Spart = "Doc";
                string ID = LID.Substring(position + 1);
                int IDval = Int32.Parse(ID);
                int Nid = ++IDval;
                string Ipart = Nid.ToString();
                NewID = string.Concat(Spart, Ipart);
            }
            if (temp == 0)
            {
                string query = "EXEC Add_SpecialityDetails'" + NewID + "','" + speciality + "','" + gender + "'EXEC Add_TelNo'" + NewID + "','" + PNO + "'EXEC Add_DeatailsOfDoctor'" + NewID + "','" + first + "','" + last + "','" + address + "','" + uname + "','" + password + "'";
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