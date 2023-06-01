
$(function () {
    debugger;
    getCustomers();
});
function getCustomers() {
    
    $.ajax({
        type: "GET",
        url: "/Customer/ShowCustomerList",
    
        success: function (data) {
            debugger;
            $('#customertable').DataTable().clear().destroy();

            $('#customertable').dataTable({
                processing: true,

                "aaData": data,
                "order": [[0, 'desc']],
                "columns": [
                    //{
                    //    "data": "id",
                    //    visible: false,
                    //    searchable: false,
                    //},

                    { "data": "customer_id" },
                    { "data": "customer_name" },
                    { "data": "parent_name" },
                    { "data": "address" },
                    { "data": "city" },
                 /*   { "data": "customer_email" },*/
                    { "data": "mobile_number" },
                    {
                        "data": "created_date",
                        render : DataTable.render.datetime("M/D/YYYY")
              
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<img src="/Image/edit.png"  height="20" width="20"  id="btneditproduct" onclick="showeditcustomermodal(' + row.customer_id + ')"  title="Edit"  data-id=' + row.customer_id + '>&nbsp;&nbsp;&nbsp;&nbsp; <img src="/Image/delete.png"  height="20" width="20"  id="btneditproduct" onclick="deletecompanydetail(' + row.customer_id + ')"  title="Delete"  data-id=' + row.customer_id + '>'
                            
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



function showeditcustomermodal(id) {
    debugger;
    $('#EditProdModal').modal("show");

    $.get("/Customer/Editcustomer/" + id,

        function (res) {
            debugger;
            if (res) {
                $('#editModalBody').html(res);
            } else {
                alert("Unsuccessful");
            }

        });

};

function Update() {
    debugger;

    var result = validate();
    debugger;
    if (result == false) {
        return false;
    }
    
    var data = new FormData();
    var form_data = $('#edit_customer_form').serializeArray();
    $.each(form_data, function (key, input) {
        data.append(input.name, input.value)
    });

    $.ajax({
        type: "POST",
        url: "/Customer/UpdateCustomer/",
        dataType: 'json',
        processData: false,
        contentType: false,
        data: data,
        success: function (data) {
            debugger;
            alert("Updation successfull");
            getCustomers();

        },

        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }

    });
}


function deletecompanydetail(id) {
    var result = confirm("Are you sure want to delete?")
    if (result) {
        $.ajax({
            type: "GET",
            url: "/Customer/DeleteCustomer/" + id,
            success: function (data) {
                debugger;
                alert("Customer details deleted");
                getCustomers();

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


function add_customer() {
    debugger;
    

    var data = new FormData();
    var form_data = $('#add_customer_form').serializeArray();
    debugger;
    $.ajax({
        url: '/Customer/AddCustomer',
        type: "post",
        dataType: 'json',
        processData: false,
        contentType: false,
        data: data,

        success: function (data) {
            debugger;
            if (data == 1) {

                alert("Customer Added");

            }
            else {
                alert("Please try again");

            }


        }

    });


}

function EditCloseModal() {
    $('#EditProdModal').modal("hide");
}



//function validate() {
//    debugger;
//    var result = true;



//    var customername = $("#customer_name").val();
//    if (customername == "") {
//        result = false;
//        $("#ecustomername").html("please enter customer name");

//    }
//    else {
//        $("#ecustomername").html("");
//    }

//    var parentname = $("#parent_name").val();
//    if (parentname == "") {
//        result = false;
//        $("#eparentname").html("please enter parent name");

//    }
//    else {
//        $("#eparentname").html("");
//    }


//    var address = $("#address").val();
//    if (address == "") {
//        result = false;
//        $("#eaddress").html("please enter address");

//    }
//    else {
//        $("#eaddress").html("");
//    }


//    var city = $("#city").val();
//    if (city == "") {
//        result = false;
//        $("#ecity").html("please enter city");

//    }
//    else {
//        $("#ecity").html("");
//    }

//    var customeremail = $("#customer_email").val();
//    debugger;
//    if (customeremail == "") {
//        result = false;
//        $("#ecustomeremail").html("please enter customer email");

//    }
//    else {
//        $("#ecustomeremail").html("");
//    }


//    var mobilenumber = $("#mobile_number").val();
//    if (mobilenumber == "") {
//        result = false;
//        $("#emobilenumber").html("please enter mobile number");

//    }
//    else {
//        $("#emobilenumber").html("");
//    }




//    return result;

//}


   


//it show the customerdetail

