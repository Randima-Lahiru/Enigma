function loadHospital() {
    
    //$("h5").show();
    var dataObject = {};
   
    Hospital();

    function Hospital() {
        
        dataObject.DoctorID = document.getElementById("Doctor").value;
        
    }

   
    $.ajax({
        url: "http://localhost:43596/api/SelectDoctor/LoadHospital",
        type: "POST",
        data: JSON.stringify(dataObject),
        contentType: "application/json",
        success: function (response) {
            var option = "<option>Select Hospital</option>";
            for (var i = 0; i < response.length; i++) {
                option += '<option value="' + response[i].HospitalID + '">' + response[i].HospitalID + '</option>';
            }
            $('#Hospital').append(option);
          
            },
        error: function ajaxError(response) {
            alert(response.status + ':' + response.statusText)
        }

    });
}


