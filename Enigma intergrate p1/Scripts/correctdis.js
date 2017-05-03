function correctdis() {
    $("h4").show();
    var dataObject = {};
    

    dataObject.id1 = document.getElementById("anothersym").value;
    

    $.ajax({
        url: "http://localhost:43596/api/Sypmtom2/SendanotherSym",
        type: "POST",
        data: JSON.stringify(dataObject),
        contentType: "application/json",
        success: function (response) {
           
            for (i = 0; i < response.length; i++) {
                document.getElementById('ccc').innerHTML = response[i].id1;
            }
            if (response[0].id1 != null) {
                var dis3 = response[0].id1;
               
                    finddoctor(dis3);
                
            }
         
            
        },
        error: function () {

        }

    });
}