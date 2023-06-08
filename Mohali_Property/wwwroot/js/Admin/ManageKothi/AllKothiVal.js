


    $(function () {
        getkothies();
    });
    function getkothies() {
        $.ajax({
            type: "GET",
            url: "/Kothi/getkothieslist",
            success: function (data) {
                debugger;
                $('#kothitable').DataTable().clear().destroy();

                $('#kothitable').dataTable({
                    processing: true,

                    "aaData": data,
                    "order": [[0, 'desc']],
                    "columns": [
                        //{
                        //    "data": "id",
                        //    visible: false,
                        //    searchable: false,
                        //},

                        { "data": "kothi_id" },
                        { "data": "kothi_Number" },
                        { "data": "block" },
                        { "data": "kothi_size" },
                        { "data": "dimension" },
                        { "data": "price" },
                       
                        {
                            "mRender": function (data, type, row) {
                                //return ' <a id="btneditproduct" onclick="showeditcompanymodal(' + row.company_id + ')"  title="Edit" class="btn-text-size btn btn-primary btneditproduct" data-id=' + row.id + '>Edit</a>';
                                //return ' <a   class="btn-text-size " href="/Admin/editProduct/' + row.id+'" >Edit</a>';
                                return '<img src="/Image/edit.png"  height="20" width="20"  id="btneditproduct" style="cursor:pointer" onclick="showeditkothimodal(' + row.kothi_id + ')"  title="Edit"  data-id=' + row.company_id + '>&nbsp;&nbsp;&nbsp;&nbsp; <img src="/Image/delete.png"  height="20" width="20"  id="btneditproduct" style="cursor:pointer" onclick="deletekothidetal(' + row.kothi_id + ')"  title="Delete"  data-id=' + row.company_id + '>'
                            }

                        },







                    ]
                })

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }



    //it show the comopanydetail in editing mode

function showeditkothimodal(id) {
        $.get("/Kothi/Edit_kothi/" + id,

            function (res) {
                debugger;
                if (res) {
                    $('#editModalBody').html(res);
                } else {
                    alert("Unsuccessful");
                }

            });

    $('#EditProdModal').modal("show");
    }





function Update() {
    debugger;
    var result = true;
        //var result = validate();
            if (result == false) {
                    return false;
                }
            else {
                //var kothi_id = $("#kothi_id");
                var data = new FormData();
                var form_data = $('#edit_kothi_form').serializeArray();
                $.each(form_data, function (key, input) {
                    data.append(input.name, input.value)
                });
                

               
                    $.ajax({
                        url: '/Kothi/update_kothi',
                        type: "post",
                        dataType: 'json',
                        processData: false,

                        contentType:false,
                        data: data,

                        success: function (res) {

                            if (res == 200) {

                                alert("Kothi Updated successfully");
                                location.reload();  
                                //$('#EditProdModal').modal("hide");

                            }
                            else {
                                alert("Please try again");

                            }
                        }
                    });
                                
                
            }

}




    function EditCloseModal() {
        $('#EditProdModal').modal("hide");
    }


function deletekothidetal(id) {
        var result = confirm("Are you sure want to delete?")
    if (result) {
        $.ajax({
            type: "GET",
            url: "/Kothi/delete_kothi/" + id,
            success: function (data) {
                debugger;
                alert("kothi details deleted");
                

            },

            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        });
        }


    }



    //function validate() {

    //        var result = true;

    //var kothino = $("#kothi_Number").val();
    //debugger;
    //if (kothino == "") {
    //            debugger;
    //result = false;


    //$("#ekothinumber").html("please enter  Kothi Number");

    //        }
    //else {

    //    $("#ekothinumber").html("");
    //        }



    //var kothiblock = $("#block").val();

    //if (kothiblock == "") {
    //    result = false;
    //$("#eblock").html("please enter Block ");
    //        }
    //else {
    //    $("#eblock").html("");
    //        }



    //var denonimation = $("#dimension").val();

    //if (denonimation == "") {
    //    result = false

    //            $("#edenomination").html("please enter Denomination ");

    //        }
    //else {
    //    $("#edenomination").html("");
                
    //        }



   



    //var kothisize = $("#kothi_size").val();

    //if (kothisize == "") {
    //    result = false;
    //$("#ekothisize").html("please enter Kothi Size ");
                
    //        }
    //else {

    //    $("#ekothisize").html("");
    //        }






    //var price = $("#price").val();

    //if (price == "") {
    //    result = false;
    //$("#eprice").html("please enter Price ");

    //        }
    //else {
    //    $("#eprice").html("");

    //        }



    //var bookingAmount = $("#booking_amount").val();
    //if (bookingAmount == "") {
    //    result = false;


    //$("#ebookingamount").html("please enter booking Amount ");
    //        }
    //else {
    //    $("#ebookingamount").html("");
    //        }






    //var status = $("#status").val();
    //if (status == "choose...") {
    //    result = false;
    //$("#estatus").html("please enter status");

    //    }
    //else {
    //    $("#estatus").html("");


    //    }



    //return result;
    //        }












