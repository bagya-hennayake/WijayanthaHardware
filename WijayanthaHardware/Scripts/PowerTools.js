$(document).ready(function () {

    $("#PowerToolId").change(function () {
        $('#item-details-Table').animate({ opacity: 0 }, 85);
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
        $('#item-details-Table').animate({ opacity: 0 }, 85);
        $.ajax({
            type: "GET",
            url: "/PowerTools/GetPowerToolSubCategoryDetail?powerToolSubCatId=" + $(this).val() + "&powerToolCategory=" + $("#PowerToolId").val(),
            success: function (data) {
                $('#item-details-Table').animate({ opacity: 1 }, 85);
                $('#ToolName').text(data.ToolName);
                $('#ToolPrice').text(data.ToolPrice + " LKR");
                $('#Details').text(data.Details);
                $('#WarrantyPeriod').text(data.WarrantyPeriod);
                $('#CostCode').text(data.CostCode);
                $('#AvailableQuantity').text(data.AvailableQuantity);
                $('#pt-edit-link').attr('href', "/PowerTools/EditPowerTool?PowerToolId=" + data.PowerToolMasterId);
            }
        });
    });
});

