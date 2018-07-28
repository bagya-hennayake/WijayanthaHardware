$(document).ready(function () {
    var paintColourId;
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

    //Type Ahead implementation
    var paintColours = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Colour'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/Paints/GetPaintColourLookup?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#searchBar').typeahead(
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
});