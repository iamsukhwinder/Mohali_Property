<script>



    function validate() {
        var result = true;

    var username = $("#username").val();

    if (username == "") {
        result = false;
    $("#eusername").html("please enter username");

        }
    else {
        $("#eusername").html("");
        }
    var password = $("#password").val();
    if (password == "") {
        result = false;
    $("#epassword").html("please enter password");

        }
    else {
        $("#epassword").html("");
        }
    if(result == false){
        $("#einvalid_input").hide();
        }

    return result;
    }













</script>