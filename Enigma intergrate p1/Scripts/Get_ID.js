function getid() {
    var dataObject = {};
    dataObject.PatientID = document.getElementById("ID").value;

    $.ajax({
        url: "http://localhost:43596/api/GetID/GetID",
        type: "POST",
        data: JSON.stringify(dataObject),
        contentType: "application/json",
        success: function (response) {
            for (var i = 0; i < response.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + response[i].ChannelingID + "</td>");
                tr.append("<td>" + response[i].DoctorName + "</td>");
                tr.append("<td>" + response[i].HospitalName + "</td>");
                tr.append("<td>" + response[i].TimeSlot + "</td>");
                tr.append("<td>" + response[i].Date + "</td>");

                $('table').append(tr);
            }

        },
        error: function ajaxError(response) {
            alert(response.status + ':' + response.statusText)
        }
    });
}