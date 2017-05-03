function Update() {
    var dataObject = {};
    dataObject.Date = document.getElementById("datepicker").value;
   
    dataObject.DoctorID = document.getElementById("Doctor").value;
    
    dataObject.HospitalID = document.getElementById("Hospital").value;
    dataObject.TimeSlot = document.getElementById("Time").value;

    $.ajax({
        url: "http://localhost:43596/api/Update/Update",
        type: "POST",
        data: JSON.stringify(dataObject),
        contentType: "application/json",
        success: function (response) {
            if (dataObject.Date == "" || dataObject.DoctorID == ""|| dataObject.HospitalID == "" || dataObject.TimeSlot == "") {
                alert("Please follow from the top!");
            }
            else {
                alert("We have confirmed your appointment");
            }
        },
        error: function ajaxError(response) {
            alert(response.status + ':' + response.statusText)
        }

    });
}
