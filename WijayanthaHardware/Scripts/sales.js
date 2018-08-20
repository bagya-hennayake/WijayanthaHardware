var paintColours = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Colour'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    remote: {
        url: '/Paints/GetPaintColourLookup?query=%QUERY',
        wildcard: '%QUERY'
    }
});

var ColourVolume = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Volume'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    remote: {
        url: '/Paints/GetVolumeLookup?query=%QUERY',
        wildcard: '%QUERY'
    }
});



counter = 0;
$("#newpaintsale").click(function () {
    event.preventDefault();
    counter++;
    var $paint = $('<div class="row"><div class="piant-details"><div class= "col-xs-6 col-sm-6 col-md-3" ><label class="small-heading">Paint category</label><select class="wide"><option value="value">text</option></select></div ><div class="col-xs-6 col-sm-6 col-md-3"><label class="small-heading">Paint</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div><div class="col-xs-6 col-sm-6 col-md-2"><label class= "small-heading">color</label ><input id="col' + counter + '"  type="text" name="name" value="" placeholder="Color" /></div ><div class="col-xs-6 col-sm-6 col-md-2"><label class="small-heading">Volume</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div><div class="col-xs-6 col-sm-6 col-md-2"><label class="small-heading">Quantity</label><input type="text" name="name" value="" placeholder="Quantity" /></div></div ></div >');
   

    $(".sales-point .paintsales").append($paint);
    $('select').niceSelect();

    $('#col' + counter).typeahead(
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

$("#newpowersale").click(function () {
    event.preventDefault();
    var $tool = $('<div class="row"><div class= "tools-details" ><div class="col-xs-6 col-sm-6 col-md-6"><label class="small-heading">Tool Category</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div><div class="col-xs-6 col-sm-6 col-md-6"><label class="small-heading">Tool</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div></div ></div >');

    $(".sales-point .power-sales").append($tool);
    $('select').niceSelect();

});

$(document).ready(function () {

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
            url: "/PowerTools/GetPowerToolSubCategoryDetail?powerToolSubCatId=" + $(this).val() + "&powerToolCategory=" + $("#PowerToolId").val(),
            success: function (data) {
                $('#item-details-Table').animate({ opacity: 1 }, 85);
                $('#ToolName').text(data.ToolName);
                $('#ToolPrice').text(data.ToolPrice + " LKR");
                $('#Details').text(data.Details);
                $('#WarrantyPeriod').text(data.WarrantyPeriod);
                $('#CostCode').text(data.CostCode);
                $('#AvailableQuantity').text(data.AvailableQuantity);
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


