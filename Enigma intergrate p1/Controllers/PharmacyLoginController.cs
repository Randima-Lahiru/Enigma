using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Eclinic.Models;

namespace Enigma_intergrate_p1.Controllers
{
    public class PharmacyLoginController : Controller
    {
        // GET: PharmacyLogin
        public ActionResult PharmacyLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PharmacyLogin(string name, string password)
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
                    string query1 = "EXEC Load_PharmacyPassword @username = '" + name + "'";
                    SqlCommand LastID = new SqlCommand(query1, conn);
                    CheckPassword = LastID.ExecuteScalar().ToString().Replace(" ", "");
                    conn.Close();
                    conn.Open();
                    string query2 = "Load_LogPatientID @username ='" + name + "'";
                    SqlCommand pid = new SqlCommand(query2, conn);
                    PID = pid.ExecuteScalar().ToString().Replace(" ", "");
                    conn.Close();
                    conn.Open();
                    string query3 = "EXEC Load_Type @username = '" + name + "'";
                    SqlCommand TYPE = new SqlCommand(query3, conn);
                    T = TYPE.ExecuteScalar().ToString().Replace(" ", "");
                    conn.Close();
                    if (T == "Doctor" || T == "Patient")
                    {
                        return RedirectToAction("Home", "Home");
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
                Session["user"] = new User() { ID = PID, Login = name, Name = name };
                return RedirectToAction("PharmacyPage", "Home");
            }
            var test2 = "Wrong Password";
            return JavaScript(test2);
        }
    }
}