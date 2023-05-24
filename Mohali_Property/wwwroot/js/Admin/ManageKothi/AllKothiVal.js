


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
                                return '<img src="/Image/edit.png"  height="20" width="20"  id="btneditproduct" onclick="showeditcompanymodal(' + row.kothi_id + ')"  title="Edit"  data-id=' + row.company_id + '>&nbsp;&nbsp;&nbsp;&nbsp; <img src="/Image/delete.png"  height="20" width="20"  id="btneditproduct" onclick="deletecompanydetail(' + row.kothi_id + ')"  title="Delete"  data-id=' + row.company_id + '>'
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

    function showeditcompanymodal(id) {
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
    };





    function Update() {
        var result = validate();
    if (result == false) {
            return false;
        }
    else{
            var valdata = $("#edit_kothi_form").serialize();
    //  alert(valdata);
    $.ajax({
        url: '/Kothi/update_kothi',
    type: "post",
    dataType: 'json',
    processData: false,

    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
    data: valdata,

    success: function (res) {

                    if (res == 1) {

        alert("Kothi Updated successfully");

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


    function deletecompanydetail(id) {
        var result = confirm("Are you sure want to delete?")
    if (result) {
        $.ajax({
            type: "GET",
            url: "/Kothi/delete_kothi/" + id,
            success: function (data) {
                debugger;
                alert("Company details deleted");
                getCompanies();

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



    function validate() {

            var result = true;

    var kothino = $("#kothi_Number").val();
    debugger;
    if (kothino == "") {
                debugger;
    result = false;


    $("#ekothinumber").html("please enter  Kothi Number");

            }
    else {

        $("#ekothinumber").html("");
            }



    var kothiblock = $("#block").val();

    if (kothiblock == "") {
        result = false;
    $("#eblock").html("please enter Block ");
            }
    else {
        $("#eblock").html("");
            }



    var denonimation = $("#dimension").val();

    if (denonimation == "") {
        result = false

                $("#edenomination").html("please enter Denomination ");

            }
    else {
        $("#edenomination").html("");
                
            }



   



    var kothisize = $("#kothi_size").val();

    if (kothisize == "") {
        result = false;
    $("#ekothisize").html("please enter Kothi Size ");
                
            }
    else {

        $("#ekothisize").html("");
            }






    var price = $("#price").val();

    if (price == "") {
        result = false;
    $("#eprice").html("please enter Price ");

            }
    else {
        $("#eprice").html("");

            }



    var bookingAmount = $("#booking_amount").val();
    if (bookingAmount == "") {
        result = false;


    $("#ebookingamount").html("please enter booking Amount ");
            }
    else {
        $("#ebookingamount").html("");
            }






    var status = $("#status").val();
    if (status == "choose...") {
        result = false;
    $("#estatus").html("please enter status");

        }
    else {
        $("#estatus").html("");


        }



    return result;
            }












