function PharmacyRegistration() {
    var dataObject = {};
    var fname;
    dataObject.FName = document.getElementById("fname").value;
    dataObject.LName = document.getElementById("lname").value;
    dataObject.UserName = document.getElementById("pname").value;
    dataObject.Address = document.getElementById("us3-address").value;
    dataObject.Lat = document.getElementById("us3-lat").value;
    dataObject.Long = document.getElementById("us3-lon").value;
    dataObject.Password = document.getElementById("password").value;

    $.ajax({
        cache: true,
        url: "http://localhost:43596/api/PharmacyRegistration/PharmacyRegistration",
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