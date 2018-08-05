$(document).ready(function () {


    $("#LoginForm").submit(function (event) {
        if (!$("#LoginForm").valid()) { return; }
        showWaitBlock();
        event.preventDefault();
        event.stopImmediatePropagation();
        var action = $("#LoginForm").attr("action");
        var dataString;
        dataString = new FormData($("#LoginForm").get(0));
        contentType = false;
        processData = false;
        $.ajax({
            type: "POST",
            url: action,
            data: dataString,
            dataType: "json",
            contentType: contentType,
            processData: processData,
            success: function (result) {
                if (result.status == "redirect") {
                    window.location.href = result.redirectURL;
                    hideWaitBlock();
                    PaintTable.clear();
                    PaintTable.rows.add(data);
                    PaintTable.draw();
                }

                else {
                    hideWaitBlock();
                    showToastr(result);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                hideWaitBlock();
                toastr.error("Something went wrong, please try refreshing the page", "Failed");
                return;
            }
        });
    });
});