var  PaintTable;
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
                PaintTable.clear();
                PaintTable.draw();
            }
        });
    });

    PaintTable = $('#paint-details-Table').DataTable({
        columns: [
            { data: "PaintColour" },
            { data: "Volume" },
            { data: "AvailableQuantity" },
            {
                data: "Price",
                render: function (data, type, row) {
                    return row.Price + " LKR";
                }
            },
            {
                data: "PaintId",
                "bSortable": false,
                render: function (data, type, row) {
                    return "<a  class='btn-load-inner-form-modal-edit' href='/Paints/EditPaint?paintId=" + row.PaintId + "'><i class='fas fa-edit'></i></a>";
                }
            }
        ]
    });

    $("#PaintSubCategoryId").change(function () {
        $.get("/Paints/GetListOfPaintsByColour?PaintCategoryId=" + $('#PaintCategoryId').val() + '&PaintSubCategoryId=' + $('#PaintSubCategoryId').val() + '&paintColourId=' + 0, function (data) {
            PaintTable.clear();
            PaintTable.rows.add(data);
            PaintTable.draw();
        });
    });
});


