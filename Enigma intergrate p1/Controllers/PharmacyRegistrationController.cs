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
    public class PharmacyRegistrationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PharmacyRegistration(RegisterPharmacy pharmacy)
        {
            string Fname = pharmacy.FName;
            string Lname = pharmacy.LName;
            string Address = pharmacy.Address;
            string PName = pharmacy.PharmacyName;
            string Uname = pharmacy.UserName;
            string Lat = pharmacy.Lat;
            string Long = pharmacy.Long;
            string Password = pharmacy.Password;
            string NewID;
            int temp;

            using (SqlConnection conn = new SqlConnection())

            {
                conn.ConnectionString = "Data Source=DESKTOP-3SOIUD0\\SQLEXPRESS;Initial Catalog=Eclinic;Integrated Security=True;";
                conn.Open();
                string query1 = "EXEC Load_PharmacyID";
                SqlCommand LastID = new SqlCommand(query1, conn);
                string LID = LastID.ExecuteScalar().ToString().Replace(" ", "");
                conn.Close();
                conn.Open();
                string checkuname = "select count(*) from NormalUser where UserName = '" + Uname + "'";
                SqlCommand com = new SqlCommand(checkuname, conn);
                temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();

                int position = LID.IndexOf("a");
                string Spart = "Pha";
                string ID = LID.Substring(position + 1);
                int IDval = Int32.Parse(ID);
                int Nid = ++IDval;
                string Ipart = Nid.ToString();
                NewID = string.Concat(Spart, Ipart);
            }
            if (temp == 0)
            {
                string query = "EXEC Add_Pharmacy'" + NewID + "','" + Uname + "','" + Lat + "','" + Long + "'EXEC Add_DetailsOfPharmacy'" + NewID + "','" + Fname + "','" + Lname + "','" + Address + "','" + Uname + "','" + Password + "'";
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
