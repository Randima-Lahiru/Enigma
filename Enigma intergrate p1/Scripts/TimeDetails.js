function Time() {
    var dataObject = {};
    var fname;
    dataObject.ID = document.getElementById("ID").value;
    dataObject.Hospital = document.getElementById("Hospital").value;

    dataObject.Sday = document.getElementById("Sday").value;
    dataObject.Eday = document.getElementById("Eday").value;

    dataObject.Mon = document.getElementById("Mon").value;
    dataObject.MStime = document.getElementById("MStime").value;
    dataObject.MEtime = document.getElementById("MEtime").value;

    dataObject.Tue = document.getElementById("Tue").value;
    dataObject.TStime = document.getElementById("TStime").value;
    dataObject.TEtime = document.getElementById("TEtime").value;

    dataObject.Wed = document.getElementById("Wed").value;
    dataObject.WStime = document.getElementById("WStime").value;
    dataObject.WEtime = document.getElementById("WEtime").value;

    dataObject.Thu = document.getElementById("Thu").value;
    dataObject.THStime = document.getElementById("THStime").value;
    dataObject.THEtime = document.getElementById("THEtime").value;

    dataObject.Fri = document.getElementById("Fri").value;
    dataObject.FStime = document.getElementById("FStime").value;
    dataObject.FEtime = document.getElementById("FEtime").value;

    dataObject.Sat = document.getElementById("Sat").value;
    dataObject.SAStime = document.getElementById("SAStime").value;
    dataObject.SAEtime = document.getElementById("SAEtime").value;

    dataObject.Sun = document.getElementById("Sun").value;
    dataObject.SUStime = document.getElementById("SUStime").value;
    dataObject.SUEtime = document.getElementById("SUEtime").value;

    $.ajax({
        url: "http://localhost:43596/api/TimeDetails/TimeDetails",
        type: "POST",
        data: JSON.stringify(dataObject),

        contentType: "application/json",
        success: function (response) {            
                alert("Sucsess");            
        },
        error: function () {

        }
    });
};