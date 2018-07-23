$(document).ready(function () {
    $("#PaintCategoryId").change(function () {
        $('#paintDetails').animate({ opacity: 0 }, 85);
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


    $("#PaintSubCategoryId").change(function () {
        $('#paintDetails').animate({ opacity: 0 }, 85);
        $.ajax({
            type: "POST",
            url: "/Paints/GetListOfPaintsByColour?PaintCategoryId=" + $('#PaintCategoryId').val() + '&PaintSubCategoryId=' + $('#PaintSubCategoryId').val() + '&paintColourId=' + 0,
            success: function (data) {
                $("#paint-details-Table > tbody").empty();
                $(data).each(function (i) {
                    $("#paint-details-Table > tbody").append("<tr><td>" + data[i].PaintColour + "</td><td>" + data[i].Volume + "</td><td>" + data[i].AvailableQuantity + "</td><td>" + data[i].Price + " LKR</td></tr>");
                });
                $('#searchBar').val("");
                if (data.length > 0)
                    $('#paintDetails').animate({ opacity: 1 }, 85);
            }
        });
    });
    //Type Ahead implementation
    //var customerViewModel = {};
    var paintColours = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Colour'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/Paints/GetPaintColourLookup?query=',//%QUERY',
            replace: function (url, uriEncodedQuery) {
                url = url + $('#searchBar').val();
                var paintSubCat = $('#PaintSubCategoryId').val();
                if (paintSubCat > 0) {
                    $('#paintDetails').animate({ opacity: 0 }, 85);
                    return url + '&PaintCategoryId=' + encodeURIComponent($('#PaintCategoryId').val()) + '&PaintSubCategoryId=' + encodeURIComponent(paintSubCat)
                }
                else
                    toastr.error("Please select a paint", "Oops!");
            },
            //wildcard: '%QUERY'
        }
    });

    $('#searchBar').typeahead(
        {
            minLength: 1,
            highlight: true
        },
        {
            name: 'paintColours',
            display: 'Colour',
            source: paintColours
        }).on("typeahead:select", function (e, paintColour) {
            var paintClolourId = paintColour.PaintColourId;
            $.ajax({
                type: "POST",
                url: "/Paints/GetListOfPaintsByColour?PaintCategoryId=" + $('#PaintCategoryId').val() + '&PaintSubCategoryId=' + $('#PaintSubCategoryId').val() + '&paintColourId=' + paintClolourId,
                success: function (data) {
                    $("#paint-details-Table > tbody").empty();
                    $(data).each(function (i) {
                        $("#paint-details-Table > tbody").append("<tr><td>" + data[i].PaintColour + "</td><td>" + data[i].Volume + "</td><td>" + data[i].AvailableQuantity + "</td><td>" + data[i].Price + " LKR</td></tr>");
                    });
                    $('#paintDetails').animate({ opacity: 1 }, 85);
                }
            });
        });
});


