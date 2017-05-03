function loadHospital() {
    var dataObject = {};
    $.ajax({
        url: "http://localhost:43596/api/Doctor/LoadHospital",
        type: "GET",
        data: JSON.stringify(dataObject),
        contentType: "application/json",
        success: function (response) {
            var option = "<option> Select Hospital</option>";
            for (var i = 0; i < response.length; i++) {
                option += '<option id="'+ i + '"value="' + response[i].Username + '">' + response[i].Username + '</option>';
            }
            $('#Hospital').append(option);

        },
        error: function () {

        }
    });
};