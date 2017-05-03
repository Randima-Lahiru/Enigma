using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eclinic.Models;
using System.Data.SqlClient;

namespace Enigma_intergrate_p1.Controllers
{
    public class PatientLoginController : Controller
    {
        // GET: PatientLogin
        public ActionResult PatientLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PatientLogin(string name, string password)
        {
            string T;
            int temp;
            string CheckPassword;
            string PID;
            using (SqlConnection conn = new SqlConnection())

            {
                conn.ConnectionString = "Data Source=DESKTOP-3SOIUD0\\SQLEXPRESS;Initial Catalog=Eclinic;Integrated Security=True";
                conn.Open();
                string checkuname = "select count(*) from NormalUser where UserName = '" + name + "'";
                SqlCommand com = new SqlCommand(checkuname, conn);
                temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();

                if (temp == 1)
                {
                    conn.Open();
                    string query1 = "EXEC Load_Password @username = '" + name + "'";
                    SqlCommand LastID = new SqlCommand(query1, conn);
                    CheckPassword = LastID.ExecuteScalar().ToString().Replace(" ", "");
                    conn.Close();
                    conn.Open();
                    string query2 = "EXEC Load_LogPatientID @username = '" + name + "'";
                    SqlCommand id = new SqlCommand(query2, conn);
                    PID = id.ExecuteScalar().ToString().Replace(" ", "");
                    conn.Close();
                    conn.Open();
                    string query3 = "EXEC Load_Type @username = '" + name + "'";
                    SqlCommand TYPE = new SqlCommand(query3, conn);
                    T = TYPE.ExecuteScalar().ToString().Replace(" ", "");
                    conn.Close();
                    if (T=="Doctor" || T=="Pharmacy") {
                        return RedirectToAction("Home","Home");
                    }
                }
                else
                {
                    var test1 = "Wrong username";
                    return JavaScript(test1);
                }



            }


            if (CheckPassword == password)
            {
                Session["user"] = new User() {Type=T, ID = PID, Login = name, Name = name };
                return RedirectToAction("Patientpage", "Home");
            }
            var test2 = "Wrong Password";
            return JavaScript(test2);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Home", "Home");
        }
    }
}