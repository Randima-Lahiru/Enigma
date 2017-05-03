using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Eclinic.Models;



namespace Enigma_intergrate_p1.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string name, string password)
        {
            int temp;
            string CheckPassword;
            using (SqlConnection conn = new SqlConnection())

            {
                conn.ConnectionString = "Data Source=DESKTOP-3SOIUD0\\SQLEXPRESS;Initial Catalog=Eclinic;Integrated Security=True";
                conn.Open();
                string checkuname = "select count(*) from AdminUser where Username = '" + name + "'";
                SqlCommand com = new SqlCommand(checkuname, conn);
                temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                if (temp == 1)
                {
                    conn.Open();
                    string query1 = "EXEC Load_AdminPassword @username = '" + name + "'";
                    SqlCommand LastID = new SqlCommand(query1, conn);
                    CheckPassword = LastID.ExecuteScalar().ToString().Replace(" ", "");
                    conn.Close();
                }
                else
                {
                    var test1 = "Wrong username";
                    return JavaScript(test1);
                }

            }


            if (CheckPassword == password)
            {
                Session["user"] = new User() { Login = name, Name = name };
                return RedirectToAction("AdminPage", "Home");
            }
            var test2 = "Password incorrect";
            return JavaScript(test2);
        }
    }
}