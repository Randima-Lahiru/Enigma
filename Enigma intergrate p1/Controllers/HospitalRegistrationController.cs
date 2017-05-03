using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using connect;
using System.Data.SqlClient;
using Eclinic.Models;

namespace Enigma_intergrate_p1.Controllers
{
    public class HospitalRegistrationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult RegisterHospital(AdminUser hospital)
        {
            string Name = hospital.Username;
            string Password = hospital.Password;
            string NewID;
            int temp;

            using (SqlConnection conn = new SqlConnection())

            {
                conn.ConnectionString = "Data Source=DESKTOP-3SOIUD0\\SQLEXPRESS;Initial Catalog=Eclinic;Integrated Security=True;";
                conn.Open();
                string query1 = "EXEC Load_HospitalID";
                SqlCommand LastID = new SqlCommand(query1, conn);
                string LID = LastID.ExecuteScalar().ToString().Replace(" ", "");
                conn.Close();
                conn.Open();
                string checkuname = "select count(*) from AdminUser where Username = '" + Name + "'";
                SqlCommand com = new SqlCommand(checkuname, conn);
                temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();

                int position = LID.IndexOf("s");
                string Spart = "Hos";
                string ID = LID.Substring(position + 1);
                int IDval = Int32.Parse(ID);
                int Nid = ++IDval;
                string Ipart = Nid.ToString();
                NewID = string.Concat(Spart, Ipart);
            }

            if (temp == 0)
            {
                string query = "EXEC Add_Hospital'" + NewID + "','" + Name + "','" + Password + "'";
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
