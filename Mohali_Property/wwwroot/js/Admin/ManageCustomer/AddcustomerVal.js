function add_customer() {
    debugger;
  
    var data = new FormData();
    var form_data = $('#add_customer_form').serializeArray();
        
    $.ajax({
        url: '/Customer/AddCustomer',
        type: "post",
        dataType: 'json',
        processData: false,
        contentType: false,
        data: data,

        success: function (res) {

            if (res == 1) {

                alert("Customer Added");

            }
            else {
                alert("Please try again");

            }


        }

    });
    

}



