function myfunction() {
    var dataObject = {};

    $.ajax({
        url: "http://localhost:43596/api/Symptom/LoadSymptom",
        type: "GET",
        data: JSON.stringify(dataObject),

        contentType: "application/json",
        success: function (response) {


          

            for (var i = 0; i < response.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + response[i].SymptomName + "</td>");
               tr.append("<td>" + "<input type=checkbox  id=" + i + " value=" + i +  ">" + "</td>");
              
                $('table').append(tr);
            }
        },
        error: function () {

        }
    });
   
}


function find() {
    
        var dataObject = {};
        var selected = [];
        var i;
        
            $('input[type="checkbox"]:checked').each(function () {
                if ($('input[type=checkbox]:checked').length > 4 || $('input[type=checkbox]:checked').length < 4) {
                    $(this).prop('checked', false);
                    alert("allowed only 4");
                }



                else {
                    selected.push($(this).val());
                }
            });
      
           

        

        for (var i = 0, len = selected.length; i < len; i++) {
            dataObject['id' + (i + 1)] = (selected[i]);

        }
        
        

        $.ajax({
            url: "http://localhost:43596/api/Symptom/SendSym",
            type: "POST",
            data: JSON.stringify(dataObject),
            contentType: "application/json",
            success: function (response) {

              //  for (var i = 0; i <response.length; i++) {

              //      document.getElementById('kkk').innerHTML = response[0].id1;
              //      document.getElementById('rrr').innerHTML = response[1].id1;
                    
              //}
                if(response.length==0)
                {
                    alert("Please meet a General doctor");
                }
                
               else if(response.length==2)
                {
                    alert("To verify correctly please select an unique symptom" + " " + response[0].id1 + "or" + response[1].id1 + "." + "");
                    document.getElementById('kkk').innerHTML = response[0].id1;
                    document.getElementById('rrr').innerHTML = response[1].id1;
                    var dis1 = response[0].id1;
                    var dis2 = response[1].id1;
                    another(dis1, dis2);
                }
                
                else if (response.length == 1) {
                    document.getElementById('kkk').innerHTML = response[0].id1;

                    alert("Most probebly you have:" + " " + response[0].id1);
                    var dis3 = response[0].id1;
                    
                    finddoctor(dis3);
                  
                   
                   // finddoctor(z);

                }
            

            },
            error: function () {

            }
     
        });
    }

  















