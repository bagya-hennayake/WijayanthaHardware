$(document).ready(function () {

    $("#PowerToolId").change(function () {
        $.ajax({
            type: "GET",
            url: "/PowerTools/GetPowerToolSubCategories?powerToolCategory=" + $(this).val(),
            success: function (data) {
                $("#PowerToolSubCategoryId").empty();
                $("#PowerToolSubCategoryId").append("<option>Select Tool</option>");
                $(data).each(function (i) {
                    $("#PowerToolSubCategoryId").append("<option value='" + data[i].PowerToolSubCategoryId + "'>" + data[i].Value + "</option>")
                });
                $('#PowerToolSubCategoryId').niceSelect('update');
            }
        });
    });
});

