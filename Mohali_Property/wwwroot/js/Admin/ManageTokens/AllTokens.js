$(function () {
    $("#Manage_tokens").addClass("active");
    gettokens();
    });
    function gettokens() {
        $.ajax({
            type: "GET",
            url: "/Token/GetTokenList",
            success: function (data) {
                debugger;
                $('#tokentable').DataTable().clear().destroy();

                $('#tokentable').dataTable({
                    processing: true,

                    "aaData": data,
                    "order": [[0, 'desc']],
                    "columns": [
                        //{
                        //    "data": "id",
                        //    visible: false,
                        //    searchable: false,
                        //},

                        { "data": "token_id" },
                        { "data": "kothi_Number" },
                        { "data": "kothi_size" },
                        { "data": "customer_name" },
                        { "data": "mobile_number" },
                        { "data": "price" },
                        { "data": "booking_amount" },
                        //{ "data": "recieved_ammount" },
                        {
                            "mRender": function (data, type, row) {
                                //return '<img src="/Image/edit.png" height="20" width="20" id="btneditproduct" onclick="showeditcompanymodal(' + row.company_id + ')" title="Edit" data-id=' + row.company_id + 
                                //'>&nbsp;&nbsp;&nbsp;&nbsp;<img src="/Image/delete.png" height="20" width="20" id="btneditproduct" onclick="deletecompanydetail(' + row.company_id + ')" title="Delete" data-id=' 
                                //+ row.company_id + '>'
                                return '<img src="/Image/delete.png" height="20" width="20" id="btneditproduct" onclick="deletetoken(' + row.token_id + ')" title="Delete" data-id='
                                    + row.token_id + '>'

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

    //to delete the token
    function deletetoken(id){
        var confirm_result  = confirm("Click on ok if you want to delete the token?")
    if(confirm_result){

        $.ajax({
            type: "GET",
            url: "/Token/delete_token/" + id,
            success: function (data) {
                if (data == 1) {
                    alert("Token deleted");
                    gettokens();

                }
                else {
                    alert("please try again");
                }

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

