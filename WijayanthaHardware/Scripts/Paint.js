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
    function typeAhead() {

    /*----------- Type Ahead implementation start -----------------*/
    var paintColours = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Colour'),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
                remote: {
                url: '/Paints/GetPaintColourLookup?query=%QUERY',
            wildcard: '%QUERY'
        }
        });

    $('.color-type').typeahead(
            {
            minLength: 1,
                highlight: true
                    //limit: Infinity
        },
        {
            name: 'paintColours',
            display: 'Colour',
            source: paintColours
        }).on("typeahead:select", function (e, paintColour) {
    paintColourId = paintColour.PaintColourId;
    });
/*---------- Type Ahead implementation end -----------------*/

    }


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


