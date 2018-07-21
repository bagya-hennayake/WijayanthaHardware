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
                //$('#ToolPrice').text('test price');
            }
        });
    });



    $("#PowerToolSubCategoryId").change(function () {
        $.ajax({
            type: "GET",
            url: "/PowerTools/GetPowerToolSubCategoryDetail?powerToolSubCatId=" + $(this).val(),
            success: function (data) {
              
                //$('#ToolPrice').text('test price');
            }
        });
    });
});

