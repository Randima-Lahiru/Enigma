function ChangePharmacyLocation() {

    var dataObject = {};
    
    dataObject.NID = document.getElementById("PID").value;
    dataObject.Address = document.getElementById("us3-address").value;
    dataObject.Lat = document.getElementById("us3-lat").value;
    dataObject.Long = document.getElementById("us3-lon").value;

    $.ajax({
        cache:true,
        url: "http://localhost:43596/api/ChangePharmacyLocation/ChangePharmacyLocation",
        type: "POST",
        data: JSON.stringify(dataObject),

        contentType: "application/json",
        success: function (response) {
                alert("Success");

            
        },
        error: function () {

        }
    });
};