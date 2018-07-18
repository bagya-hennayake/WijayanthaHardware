$(document).ready(function () {

    $("#PaintCategoryId").change(function () {
        $.ajax({
            type: "GET",
            url: "/Paints/GetPaintSubCategory?paintCategoryId=" + $(this).val(),
            success: function (data) {
                $("#PaintSubCategoryId").empty();
                $("#PaintSubCategoryId").append("<option>Select Paint</option>");
                $(data).each(function (i) {
                    $("#PaintSubCategoryId").append("<option value='" + data[i].PaintSubCategoryId + "'>" + data[i].Value + "</option>")
                });
                $('#PaintSubCategoryId').niceSelect('update');
            }

        });
    });
});

