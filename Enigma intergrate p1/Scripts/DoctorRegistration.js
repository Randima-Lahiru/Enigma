function DoctorRegistration() {
    var dataObject = {};
    var fname;
    dataObject.FName = document.getElementById("Fname").value;
    dataObject.LName = document.getElementById("Lname").value;
    dataObject.Username = document.getElementById("Username").value;
    dataObject.Password = document.getElementById("Password").value;
    dataObject.Address = document.getElementById("Address").value;
    dataObject.Speciality = document.getElementById("Speciality").value;
    dataObject.Gender = document.getElementById("Gender").value;
    dataObject.TelNo1 = document.getElementById("Pno").value;

    $.ajax({
        cache: true,
        url: "http://localhost:43596/api/DoctorRegistration/DoctorRegistration",
        type: "POST",
        data: JSON.stringify(dataObject),

        contentType: "application/json",
        success: function (response) {
            //alert("success");

            if (response.test1 == "1") {
                alert("User name already enter");

            }
        },
        error: function () {

        }
    });

};
