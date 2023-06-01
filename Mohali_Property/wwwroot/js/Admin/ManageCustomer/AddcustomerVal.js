//function validate() {
//    alert("hdkhk");
//}


//function validate() {
//    alert("hdkhk");
//}

$(function () {
    debugger;
    if ($("#ecompany").html() != '') {
        //var s = $("#icndisplay").html() + 'anil<i asp-validation-for="customer_name" class="fa fa - info - circle"></i>';
        //$("#icndisplay").html(s);
        $("#icndisplay").show();
        alert("hy");
    }
    else {

        alert("no");
    }
    var result = $("#ecompany").attr("data-valmsg-replace").val();
    alert(result);
});




function validate() {
    debugger;
    var result = true;
   


    var customername = $("#customer_name").val();
    if (customername == "") {
        result = false;
        $("#ecustomername").html("please enter customer name");

    }
    else {
        $("#ecustomername").html("");
    }

    var parentname = $("#parent_name").val();
    if (parentname == "") {
        result = false;
        $("#eparentname").html("please enter parent name");

    }
    else {
        $("#eparentname").html("");
    }


    var address = $("#address").val();
    if (address == "") {
        result = false;
        $("#eaddress").html("please enter address");

    }
    else {
        $("#eaddress").html("");
    }




    var customeremail = $("#customer_email").val();
    if (customeremail == "") {
        result = false;
        $("#ecustomeremail").html("please enter customer email");

    }
    else {
        $("#ecustomeremail").html("");
    }


    var city = $("#city").val();
    if (city == "") {
        result = false;
        $("#ecity").html("please enter city");

    }
    else {
        $("#ecity").html("");
    }

    


    var mobilenumber = $("#mobile_number").val();
    if (mobilenumber == "") {
        result = false;
        $("#emobilenumber").html("please enter mobile number");

    }
    else {
        $("#emobilenumber").html("");
    }

    var createddate = $("#created_date").val();
    if (createddate == "") {
        result = false;
        $("#ecreateddate").html("please enter date");

    }
    else {
        $("#ecreateddate").html("");
    }



    return result;

}




