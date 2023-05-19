



    function add_company(){

        validate();
    var data = new FormData();
    var form_data = $('#add_company_form').serializeArray();
    $.each(form_data, function (key, input) {
        data.append(input.name, input.value)
    });

    var image = $("#company_logo").val();
    if (image != '') {
            var file_data = $('input[name = company_logo]')[0].files;
    for (var i = 0; i < file_data.length; i++) {
        data.append("image", file_data[i]);
            }
    $.ajax({
        url: '/Admin/AddCompanyDetail',
    type: "post",
    dataType: 'json',
    processData: false,
    contentType: false,
    data: data,

    success: function (res) {

                    if (res == 1) {

        alert("Company Added");
                        
                    }
    else {
        alert("Please try again");

                    }
    if(res == 300){
        alert("only image is alowed to upload");
                    }
    if(res == 301){
        alert("please upload only one file");
                    }
                    
                }

            });

        }
        
    }









    function validate() {
            var result = true;

    var company = $("#company").val();

    if (company == "") {
        result = false;
    $("#ecompany").html("please enter company ");

            }
    else {
        $("#ecompany").html("");
            }


    var companyname = $("#companyname").val();
    if (companyname == "") {
        result = false;
    $("#ecompanyname").html("please enter company name");

            }
    else {
        $("#ecompanyname").html("");
            }

    var email = $("#email").val();
    if (email == "") {
        result = false;
    $("#eemail").html("please enter email");

        }
    else {
        $("#eemail").html("");
        }


    var address = $("#address").val();
    if (address == "") {
        result = false;
    $("#eaddress").html("please enter address");

        }
    else {
        $("#eaddress").html("");
        }


    var city = $("#city").val();
    if (city == "") {
        result = false;
    $("#ecity").html("please enter city");

        }
    else {
        $("#ecity").html("");
        }

    var state = $("#state").val();
    debugger;
    if (state == "choose...") {
        result = false;
    $("#estate").html("please select state");

        }
    else {
        $("#estate").html("");
        }


    var pincode = $("#pincode").val();
    if (pincode == "") {
        result = false;
    $("#epincode").html("please enter pincode");

        }
    else {
        $("#epincode").html("");
        }

    var website = $("#website").val();
    if (website == "") {
        result = false;
    $("#ewebsite").html("please enter website");

        }
    else {
        $("#ewebsitee").html("");
        }

    var gst = $("#gst").val();
    if (gst == "") {
        result = false;
    $("#egst").html("please enter gst");

        }
    else {
        $("#egst").html("");
        }




    var status = $("#status").val();
    if (status == "choose...") {
        result = false;
    $("#estatus").html("please enter status");

        }
    else {
        $("#estatus").html("");
        }





    var mobilenumber = $("#mobilenumber").val();
    if (mobilenumber == "") {
        result = false;
    $("#emobilenumber").html("please enter moblie number");

        }
    else {
        $("#emobilenumber").html("");
        }

    var landlinenumber = $("#landlinenumber").val();
    if (landlinenumber == "") {
        result = false;
    $("#elandlinenumber").html("please enter landline number");

        }
    else {
        $("#elandlinenumber").html("");
        }


    var company_logo = $("#company_logo").val();
    if (company_logo == "") {
        result = false;
    $("#ecompany_logo").html("please insert logo");

        }
    else {
        $("#ecompany_logo").html("");
        }


    return result;
        }

