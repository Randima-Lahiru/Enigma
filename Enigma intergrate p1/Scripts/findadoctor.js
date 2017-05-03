function finddoctor(id1)
{

    var dataObject = {id1};
    

       



        $.ajax({
            url: "http://localhost:43596/api/finddoctor/getDoctor",
            type: "POST",
           data: JSON.stringify(dataObject),

           contentType: "application/json",
           success: function (response) {
                {
                   var option = "<option>Select a Doctor</option>";
                 for (var i = 0; i < response.length; i++) {
                     option += '<option id="' + i + '" value="' + response[i].id1 + '">' + response[i].id1 + '</option>';

                   }
                   $('#Doctor').append(option);
                   $("#Doctor").change(function () {
                       loadHospital();
                       var my_condition = true;
                       var lastSel = $("#Doctor option:selected");

                       $("#Doctor").change(function () {
                           if (my_condition) {
                               lastSel.attr("selected", true);
                           }
                       });

                       $("#Doctor").click(function () {
                           lastSel = $("#Doctor option:selected");
                       });

                   });
               }




                },
               error: function () {

               }

            });

}