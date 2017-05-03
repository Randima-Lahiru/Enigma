using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using enigmaApp.Models;
using enigmaApp;
using System.Web.Services;
using connect;

namespace Enigma_intergrate_p1.Controllers
{
    public class MakeAppointmentController : ApiController
    {
        [HttpPost]
        public IHttpActionResult MakeAppointment(Test appointment)
        {
            string a = appointment.Date;
            string b = appointment.DoctorID;
            string c = appointment.HospitalID;
            string d = appointment.TimeSlot;
            string e = appointment.PatientID;
            if (appointment.Date == null)
            {
                a = "";
            }
            else
            {
                a = appointment.Date.ToString();
            }
            if (appointment.DoctorID == null)
            {
                b = "";
            }
            else
            {
                b = appointment.DoctorID.ToString();
            }
            if (appointment.HospitalID == null)
            {
                c = "";
            }
            else
            {
                c = appointment.HospitalID.ToString();
            }
            if (appointment.TimeSlot == null)
            {
                d = "";
            }
            else
            {
                d = appointment.TimeSlot.ToString();
            }
            if (appointment.PatientID == null)
            {
                e = "";
            }
            else
            {
                e = appointment.PatientID.ToString();
            }
            string query = "EXEC [dbo].[Make_Appointment]'" + a + "','" + b + "','" + c + "','" +d+ "','" +e+"'";
            int result = connectionProvider.CreateSomething(query);
            return Ok(result);

        }
    }
}