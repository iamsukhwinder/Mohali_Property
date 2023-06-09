﻿
$(function () {
    $("#Manage_companies").addClass("active");
        getCompanies();
    });
    function getCompanies() {
        $.ajax({
            type: "GET",
            url: "/Company/GetComopanyList",
            success: function (data) {
                debugger;
                $('#companytable').DataTable().clear().destroy();

                $('#companytable').dataTable({
                    processing: true,

                    "aaData": data,
                    "order": [[0, 'desc']],
                    "columns": [
                        //{
                        //    "data": "id",
                        //    visible: false,
                        //    searchable: false,
                        //},

                        { "data": "company_id" },
                        { "data": "company_name" },
                        { "data": "company_address" },
                        { "data": "city" },
                        { "data": "state" },
                        { "data": "pin_code" },
                        { "data": "mobileNumber" },
                        { "data": "email" },
                        {
                            "mRender": function (data, type, row) {
                                //return ' <a id="btneditproduct" onclick="showeditcompanymodal(' + row.company_id + ')"  title="Edit" class="btn-text-size btn btn-primary btneditproduct" data-id=' + row.id + '>Edit</a>';
                                //return ' <a   class="btn-text-size " href="/Admin/editProduct/' + row.id+'" >Edit</a>';
                                return '<img src="/Image/edit.png"  height="20" width="20"  id="btneditproduct" onclick="showeditcompanymodal(' + row.company_id + ')"  title="Edit"  data-id=' + row.company_id + '>&nbsp;&nbsp;&nbsp;&nbsp; <img src="/Image/delete.png"  height="20" width="20"  id="btneditproduct" onclick="deletecompanydetail(' + row.company_id + ')"  title="Delete"  data-id=' + row.company_id + '>'
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
        $.get("/Company/Editcompany/" + id,

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
        //debbuger;
    if(result == false){
           return false;
       }

    var data = new FormData();
    var form_data = $('#edit_company_form').serializeArray();
    $.each(form_data, function (key, input) {
        data.append(input.name, input.value)
    });


    var image = $("#company_logo").val();
    if (image != '') {
            var file_data = $('input[name = company_logo]')[0].files;
        for (var i = 0; i < file_data.length; i++) {
            data.append("image", file_data[i]);
            }
    var state = $("#state").val();
    var status = $("#status").val();
    data.set("state",state);
    data.set("status",status);
    $.ajax({
        url: '/Company/update_company',
    type: "post",
    dataType: 'json',
    processData: false,
    contentType: false,
    data: data,

    success: function (res) {

                    if (res == 1) {

        alert("Company updated");

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
        }else{
            var imgsrc = $("#blah").attr("src");
    var imagename = imgsrc.split("/");
    if(imagename[4] != ""){
        data.set("company_logo", imagename[4]);
    var state = $("#state").val();
    data.set("state", state);
    var status = $("#status").val();
    data.set("status", status);
    $.ajax({
        url: '/Company/update_company',
    type: "post",
    dataType: 'json',
    processData: false,
    contentType: false,
    data: data,

    success: function (res) {

                    if (res == 1) {

                        alert("Company updated");
                        getCompanies();
                        EditCloseModal();

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
    }

    function EditCloseModal() {
        $('#EditProdModal').modal("hide");
    }


    function deletecompanydetail(id) {
        var result = confirm("Are you sure want to delete?")
    if (result) {
        $.ajax({
            type: "GET",
            url: "/Company/DeleteCompany/" + id,
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

    var company = $("#company").val();

    if (company == "") {
        result = false;
    $("#ecompany").html("please enter company ");

        }
    else {
        $("#ecompany").html("");
        }


    var companyname = $("#company_name").val();
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


    var address = $("#company_address").val();
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


    var pincode = $("#pin_code").val();
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

    var gst = $("#gst_number").val();
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





    var mobilenumber = $("#mobileNumber").val();
    if (mobilenumber == "") {
        result = false;
    $("#emobilenumber").html("please enter moblie number");

        }
    else {
        $("#emobilenumber").html("");
        }

    var landlinenumber = $("#landlineNo").val();
    if (landlinenumber == "") {
        result = false;
    $("#elandlinenumber").html("please enter landline number");

        }
    else {
        $("#elandlinenumber").html("");
        }












    return result;
    }















