﻿
<script>
    $(document).ready(function(){
   //     debugger;
        var s = $("#sta").val();
    $("#status").val(s);

    var states = $("#stateHide").val();
    $("#state").val(states);


    })
    // for image
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

    reader.onload = function (e) {
        $('#blah').attr('src', e.target.result).width(150).height(200);
            };

    reader.readAsDataURL(input.files[0]);
        }
    }




</script>