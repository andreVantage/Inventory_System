
$(document).ready(function () {
    $("form").on("submit", function (e) {
       
    })


    function IsValidated(e) {
        if ($("#txtName").val() === "") {
            $("#txtName").addClass("is-invalid")
            e.preventDefault();
        }
    }
})