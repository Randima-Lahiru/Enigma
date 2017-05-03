function HospitalRegistration() {
    var dataObject = {};
    var fname;
    dataObject.Username = document.getElementById("name").value;
    dataObject.Password = document.getElementById("password").value;

    $.ajax({
        cache: true,
        url: "http://localhost:43596/api/HospitalRegistration/RegisterHospital",
        type: "POST",
        data: JSON.stringify(dataObject),

        contentType: "application/json",
        success: function (response) {
            if (response.test1 == "1") {
                alert("User name already enter");

            }
        },
        error: function () {

        }
    });

};