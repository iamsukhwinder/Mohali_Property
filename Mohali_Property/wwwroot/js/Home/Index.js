$(document).ready(function () {
    //console.log(location.pathname);
    //var path = location.pathname;
    //var current_path = path.split("/");
    $("#Home").addClass("active");
    $("#search_kothies").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#kothi_data h5").filter(function () {
            debugger;
            
          
            if ($(this).text().toLowerCase().indexOf(value) > -1) {
               
                $(this).parents("#kothi_data").show();
            } else {
                $(this).parents("#kothi_data").hide();
            }
           
        });
    });

    
});
function PagerClick(index) {
    document.getElementById("hfCurrentPageIndex").value = index;
    document.forms[0].submit();
}