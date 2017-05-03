function PostDate() {
    var dataObject = {};
     dataObject.Date = document.getElementById("datepicker").value;
     dataObject.DoctorID = document.getElementById("Doctor").value;
     dataObject.HospitalID = document.getElementById("Hospital").value;

    $.ajax({
        url: "http://localhost:43596/api/PostDetails/Date",
        type: "POST",
        data: JSON.stringify(dataObject),
        contentType: "application/json",
        success: function (response) {
            var option = "<option>Select Time</option>";
            for (var i = 0; i < response.length; i++) {
                option += '<option value="' + response[i].TimeSlot + '">' + response[i].TimeSlot + '</option>';
            }
            $('#Time').append(option);
            if (dataObject.Date == "" || dataObject.DoctorID == ""|| dataObject.HospitalID == "") {
                alert("Please follow from the top!");
            }
            else {
                alert("Now select your timeslot");
            }
            


        },
        error: function ajaxError(response) {
            alert(response.status + ':' + response.statusText)
        }

    });
}
