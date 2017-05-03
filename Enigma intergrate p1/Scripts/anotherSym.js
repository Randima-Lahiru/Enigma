
function another(dis2, dis3) {
    function showdescription3() {
        document.getElementById('description3').style.display = 'block';
    }
    showdescription3();
    var dataObject = {};
    var selected = [dis2, dis3];
 
    for (var i = 0, len = selected.length; i < len; i++) {
        dataObject['id' + (i + 1)] = (selected[i]);

    }


    $.ajax({
        url: "http://localhost:43596/api/Diabetes/SendanotherSym",
        type: "POST",
        data: JSON.stringify(dataObject),
        contentType: "application/json;charset=utf-8",
        success: function (response) {
            var option = "<option>Select a symptom<option>";
            for (var i = 0; i < response.length; i++) {
                option += '<option id="' + i + '" value="' + response[i].id1 + '">' + response[i].id1 + '</option>';

            }
            $('#anothersym').append(option);
            
           
        },
        error: function () {

        }

    });



}

