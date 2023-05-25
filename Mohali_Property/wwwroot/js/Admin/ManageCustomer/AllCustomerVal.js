
$(function () {
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
                    { "data": "customer_email" },
                    { "data": "mobile_number" },
                    {
                        "data": "created_date",
                        render : DataTable.render.datetime("M/D/YYYY")
              
                    },
                    {
                        "mRender": function (data, type, row) {
                             return '<img src="/Image/edit.png"  height="20" width="20"  id="btneditproduct" onclick="showeditcompanymodal(' + row.customer_id + ')"  title="Edit"  data-id=' + row.customer_id + '>&nbsp;&nbsp;&nbsp;&nbsp; <img src="/Image/delete.png"  height="20" width="20"  id="btneditproduct" onclick="deletecompanydetail(' + row.customer_id + ')"  title="Delete"  data-id=' + row.customer_id + '>'
                            
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



//it show the customerdetail

