function MakeAppointment() {
    var dataObject = {};
    dataObject.Date = document.getElementById("datepicker").value;
   
    dataObject.DoctorID = document.getElementById("Doctor").value;
   
    dataObject.HospitalID = document.getElementById("Hospital").value;
    dataObject.TimeSlot = document.getElementById("Time").value;
    dataObject.PatientID = document.getElementById("ID").value;


    $.ajax({
        url: "http://localhost:43596/api/MakeAppointment/MakeAppointment",
        type: "POST",
        data: JSON.stringify(dataObject),
        contentType: "application/json",
        success: function (response) {
            if (dataObject.Date == "" || dataObject.DoctorID == "" || dataObject.HospitalID == "" || dataObject.TimeSlot == ""|| dataObject.TimeSlot=="") {
                alert("Please follow from the Top");
            }
            else {
                alert(dataObject.Date + "and" + dataObject.DoctorID + "and" + dataObject.HospitalID+ "and" + dataObject.TimeSlot);
            }
         },
        error: function ajaxError(response) {
            alert(response.status + ':' + response.statusText)
        }

    });
}
