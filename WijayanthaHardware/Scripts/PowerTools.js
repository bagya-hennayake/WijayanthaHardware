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



    $("#PowerToolSubCategoryId").change(function () {
        $.ajax({
            type: "GET",
            url: "/PowerTools/GetPowerToolSubCategoryDetail?powerToolSubCatId=" + $(this).val(),
            success: function (data) {
                $('#item-details-Table').removeAttr("hidden").animate({ opacity: 1 }, 85);
                $('#ToolName').text(data.ToolName);
                $('#ToolPrice').text(data.ToolPrice);
                $('#ToolBrand').text(data.ToolBrand);
                $('#WarrantyPeriod').text(data.WarrantyPeriod);
                $('#CostCode').text(data.CostCode);
                $('#AvailableQuantity').text(data.AvailableQuantity);
            }
        });
    });
});

