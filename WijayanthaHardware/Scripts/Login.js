$(document).ready(function () {


    $("#LoginForm").submit(function (event) {
        if (!$("#LoginForm").valid()) { return; }
        event.preventDefault();
        event.stopImmediatePropagation();
        var action = $("#LoginForm").attr("action");
        var dataString;
        dataString = new FormData($("#LoginForm").get(0));
        contentType = false;
        processData = false;
        $.ajax({
            type: "POST",
            url: '/Security/Login',
            data: dataString,
            dataType: "json",
            contentType: contentType,
            processData: processData,
            success: function (result) {
                if (result.status == "redirect") {
                    window.location.href = result.redirecURL;
                }

                else {
                    showToastr(result);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {

                toastr.error("Something went wrong, please try refreshing the page", "Failed");
                return;
            }
        });
    });
});