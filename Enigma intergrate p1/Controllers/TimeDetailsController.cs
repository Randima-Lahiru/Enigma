using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eclinic.Models;
using connect;
using System.Data.SqlClient;

namespace Enigma_intergrate_p1.Controllers
{
    public class TimeDetailsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult TimeDetails(DoctorAvailability time)
        {
            string Hospital = time.Hospital;
            string ID = time.ID;
            int temp;
            string fullname;

            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=DESKTOP-3SOIUD0\\SQLEXPRESS;Initial Catalog=Eclinic;Integrated Security=True;";
        
                conn.Open();
                string checkuname = "select count(*) from Hospital where NID = '" + ID + "' AND HospitalName ='" + Hospital + "'";
                SqlCommand com = new SqlCommand(checkuname, conn);
                temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                conn.Open();
                string query1 = "select FName from NormalUser where NID = '" + ID + "'";
                SqlCommand Fname = new SqlCommand(query1, conn);
                string frist = Fname.ExecuteScalar().ToString().Replace(" ", "");
                conn.Close();
                conn.Open();
                string query2 = "select LName from NormalUser where NID = '" + ID + "'";
                SqlCommand Lname = new SqlCommand(query2, conn);
                string Last = Lname.ExecuteScalar().ToString().Replace(" ", "");
                conn.Close();
                fullname = string.Concat("Dr", " ", frist, " ", Last);
            }
            if(temp == 0)
            {
                string query = "EXEC Add_DeatailsToHospital '" + ID + "','" + Hospital + "'";
                int r = connectionProvider.CreateSomething(query);
            }
           
            DateTime Sday = Convert.ToDateTime(time.Sday);
            DateTime Eday = Convert.ToDateTime(time.Eday);

            string Mon = time.Mon;
            DateTime MStime = Convert.ToDateTime(time.MStime);
            DateTime MEtime = Convert.ToDateTime(time.MEtime);

            string Tue = time.Tue;
            DateTime TStime = Convert.ToDateTime(time.TStime);
            DateTime TEtime = Convert.ToDateTime(time.TEtime);

            string Wed = time.Wed;
            DateTime WStime = Convert.ToDateTime(time.WStime);
            DateTime WEtime = Convert.ToDateTime(time.WEtime);

            string Thu = time.Thu;
            DateTime THStime = Convert.ToDateTime(time.THStime);
            DateTime THEtime = Convert.ToDateTime(time.THEtime);

            string Fri = time.Fri;
            DateTime FStime = Convert.ToDateTime(time.FStime);
            DateTime FEtime = Convert.ToDateTime(time.FEtime);

            string Sat = time.Sat;
            DateTime SAStime = Convert.ToDateTime(time.SAStime);
            DateTime SAEtime = Convert.ToDateTime(time.SAEtime);

            string Sun = time.Sun;
            DateTime SUStime = Convert.ToDateTime(time.SUStime);
            DateTime SUEtime = Convert.ToDateTime(time.SUEtime);
            int dayvalue;
            string rangebegin;
            string rangeend;
            string rangerbegin1;
            string a = " to ";


            for ( DateTime d = Sday; d <= Eday; d = d.AddDays(1))
            {
                DateTime date = d.Date;
                dayvalue = ((int)d.DayOfWeek);
                switch (dayvalue)
                {
                    case 1:
                        for(DateTime t = MStime;t<MEtime;)
                        {
                            rangebegin = Convert.ToString(t.TimeOfDay);                            
                            t = t.AddMinutes(30);
                            rangeend = Convert.ToString(t.TimeOfDay);
                            rangerbegin1 = string.Concat(rangebegin, a);
                            string TimeSlot = string.Concat(rangerbegin1, rangeend);
                            string query2 = "EXEC Add_Available'" + fullname + "','" + date + "','" + TimeSlot + "','" + Hospital + "'";
                            int r = connectionProvider.CreateSomething(query2);
                        }
                    break;
                    case 2:
                        for (DateTime t = TStime; t < TEtime;)
                        {
                            rangebegin = Convert.ToString(t.TimeOfDay);
                            t = t.AddMinutes(30);
                            rangeend = Convert.ToString(t.TimeOfDay);
                            rangerbegin1 = string.Concat(rangebegin, a);
                            string TimeSlot = string.Concat(rangerbegin1, rangeend);
                            string query2 = "EXEC Add_Available'" + fullname + "','" + date + "','" + TimeSlot + "','" + Hospital + "'";
                            int r = connectionProvider.CreateSomething(query2);
                        }
                     break;
                    case 3:
                        for (DateTime t = WStime; t < WEtime;)
                        {
                            rangebegin = Convert.ToString(t.TimeOfDay);
                            t = t.AddMinutes(30);
                            rangeend = Convert.ToString(t.TimeOfDay);
                            rangerbegin1 = string.Concat(rangebegin, a);
                            string TimeSlot = string.Concat(rangerbegin1, rangeend);
                            string query2 = "EXEC Add_Available'" + fullname + "','" + date + "','" + TimeSlot + "','" + Hospital + "'";
                            int r = connectionProvider.CreateSomething(query2);
                        }
                    break;
                    case 4:
                        for (DateTime t = THStime; t < THEtime;)
                        {
                            rangebegin = Convert.ToString(t.TimeOfDay);
                            t = t.AddMinutes(30);
                            rangeend = Convert.ToString(t.TimeOfDay);
                            rangerbegin1 = string.Concat(rangebegin, a);
                            string TimeSlot = string.Concat(rangerbegin1, rangeend);
                            string query2 = "EXEC Add_Available'" + fullname + "','" + date + "','" + TimeSlot + "','" + Hospital + "'";
                            int r = connectionProvider.CreateSomething(query2);
                        }
                    break;
                    case 5:
                        for (DateTime t = FStime; t < FEtime;)
                        {
                            rangebegin = Convert.ToString(t.TimeOfDay);
                            t = t.AddMinutes(30);
                            rangeend = Convert.ToString(t.TimeOfDay);
                            rangerbegin1 = string.Concat(rangebegin, a);
                            string TimeSlot = string.Concat(rangerbegin1, rangeend);
                            string query2 = "EXEC Add_Available'" + fullname + "','" + date + "','" + TimeSlot + "','" + Hospital + "'";
                            int r = connectionProvider.CreateSomething(query2);
                        }
                        break;
                    case 6:
                        for (DateTime t = SAStime; t < SAEtime;)
                        {
                            rangebegin = Convert.ToString(t.TimeOfDay);
                            t = t.AddMinutes(30);
                            rangeend = Convert.ToString(t.TimeOfDay);
                            rangerbegin1 = string.Concat(rangebegin, a);
                            string TimeSlot = string.Concat(rangerbegin1, rangeend);
                            string query2 = "EXEC Add_Available'" + fullname + "','" + date + "','" + TimeSlot + "','" + Hospital + "'";
                            int r = connectionProvider.CreateSomething(query2);
                        }
                        break;
                    case 0:
                        for (DateTime t = SUStime; t < SUEtime;)
                        {
                            rangebegin = Convert.ToString(t.TimeOfDay);
                            t = t.AddMinutes(30);
                            rangeend = Convert.ToString(t.TimeOfDay);
                            rangerbegin1 = string.Concat(rangebegin, a);
                            string TimeSlot = string.Concat(rangerbegin1, rangeend);
                            string query2 = "EXEC Add_Available'" + fullname + "','" + date + "','" + TimeSlot + "','" + Hospital + "'";
                            int r = connectionProvider.CreateSomething(query2);
                        }
                        break;
                }
            }

            return Ok();
        }
    }
}
