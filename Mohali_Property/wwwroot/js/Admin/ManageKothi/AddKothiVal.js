
    function  add_kothi()
    {
        validate();
        var data = new FormData();
        var form_data = $('#form').serializeArray();
        $.each(form_data, function (key, input) {
            data.append(input.name, input.value)
        });

        var image = $("#kothi_image").val();
        if (image != '') {
            var file_data = $('input[name = kothi_image]')[0].files;
            for (var i = 0; i < file_data.length; i++) {
                data.append("image", file_data[i]);
            }
            $.ajax({
                url: '/Kothi/Add_kothi',
                type: "post",
                dataType: 'json',
                processData: false,
                contentType: false,
                data: data,

                success: function (res) {

                    if (res == 1) {


                        alert("kohti Added");


                    }
                    else {
                        alert("Please try again");

                    }
                    if (res == 300) {
                        alert("only image is alowed to upload");
                    }
                    if (res == 301) {
                        alert("please upload only one file");
                    }

                }

            });

        }

                
    }



    function validate()
    {

        var result = true;

    var kothi_Number = $("#kothi_Number").val();
    debugger;
    if (kothi_Number == "") {
            debugger;
    result = false;
    $("#ekothinumber").html("please enter  Kothi Number");

        }
    else {
        $("#ekothinumber").html("");
           
        }



    var block = $("#block").val();

    if (block == "") {
        result = false;
    $("#eblock").html("please enter Block ");

        }
    else {
        $("#eblock").html("");
           
        }


    var dimension = $("#dimension").val();

    if (dimension == "") {
        result = false;

    $("#edenomination").html("please enter Denomination ");

        }
    else {
        $("#edenomination").html("");
        }



    var kothi_unit = $("#plot_area").val();

    if (kothi_unit == "") {
        result = false;

    $("#eplotarea").html("please enter Plot Area ");
        }
    else {
        $("#eplotarea").html("");
            
        }



    var kothi_size = $("#kothi_size").val();

    if (kothi_size == "") {
        result = false;

    $("#ekothisize").html("please enter Kothi Size ");
        }
    else {
        $("#ekothisize").html("");
          
        }



    //var unit_rate = $("#unit_rate").val();

    //if (unit_rate == "") {
    //    result = false;
    //$("#eunitrate").html("please enter Unit rate ");

    //        }
    //else {
    //    $("#eunitrate").html("");
           
    //        }



    var token_amount = $("#price").val();

    if (token_amount == "") {
        result = false;
    $("#eprice").html("please enter Price ");

        }
    else {

        $("#eprice").html("");
        }



    var bookingAmount = $("#booking_amount").val();
    if (bookingAmount == "")
    {
        result = false;
    $("#ebookingamount").html("please enter booking Amount ");

        }
    else {

        $("#ebookingamount").html("");
        }



    //var token_amount = $("#token_amount").val();

    //if (token_amount == "") {
    //    result = false;

    //$("#etokenamount").html("please enter Token Amount ");
    //    }
    //else {
    //    $("#etokenamount").html("");;
    //    }



    var status = $("#status").val();
    if (status == "choose...") {
        result = false;
    $("#estatus").html("please enter status");

        }
    else {
        $("#estatus").html("");
         
            
        }

    return  result;
            }


