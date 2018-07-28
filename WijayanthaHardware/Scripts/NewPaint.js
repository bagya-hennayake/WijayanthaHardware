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

    /*----------- Type Ahead implementation start -----------------*/
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
    /*---------- Type Ahead implementation end -----------------*/


    $('div.row.itemlist input[type=checkbox]').on('click', function () {
        var isChecked = $(this).is(':checked');
        if (isChecked) {
            $(this).closest('div.row.itemlist').attr('value', 'selectedToAdd').find('input[type="text"],[type="number"]').prop('disabled', !isChecked);
        }
        else {
            $(this).closest('div.row.itemlist').attr('value', '').find('input[type="text"],[type="number"]').prop('disabled', !isChecked).val('');
        }
    });
    var loopErrorMsg = "";
    $("#AddPaints").submit(function (event) {
        event.preventDefault();
        event.stopImmediatePropagation();
        if ($("#PaintCategoryId").val() < 1) return toastr.error("Paint Category not selected", "Failed");
        if ($("#PaintSubCategoryId").val() < 1 || $("#PaintSubCategoryId").val() == "Select Paint") return toastr.error("Paint Sub Category not selected", "Failed");
        if (paintColourId < 1 || paintColourId == undefined || $('#searchBar').val() == "") return toastr.error("Paint colour not selected", "Failed");

        var action = $("#AddPaints").attr("action");

        var isRowEmpty = false;
        var newPaintDetails = [];
        $('div.row.itemlist[value=selectedToAdd]').each(function (i, obj) {
            if (obj.children[0].children[1].children[0].value == null || obj.children[0].children[1].children[0].value == "") {
                isRowEmpty = true;
                loopErrorMsg = "One or more rows have empty cost code"; return;
            }
            if (obj.children[0].children[2].children[0].value == null || obj.children[0].children[2].children[0].value == "") {
                isRowEmpty = true;
                loopErrorMsg = "One or more rows have empty price", "Failed"; return;
            }
            if (obj.children[0].children[3].children[0].value == null || obj.children[0].children[3].children[0].value == "") {
                isRowEmpty = true;
                loopErrorMsg = "One or more rows have empty quantity"; return;
            }

            var PaintsToAdd = {
                PaintCategoryId: $("#PaintCategoryId").val(),
                PaintSubCategoryId: $("#PaintSubCategoryId").val(),
                ColourId: paintColourId,
                VolumeId: obj.attributes.id.nodeValue,
                CostCode: obj.children[0].children[1].children[0].value,
                Price: obj.children[0].children[2].children[0].value,
                Quantity: obj.children[0].children[3].children[0].value
            }
            newPaintDetails.push(PaintsToAdd);
        });

        if (newPaintDetails.length == 0 && isRowEmpty == false) {

            toastr.error("No paints have been selected to save", "Failed");
            return;
        }
        if (isRowEmpty) return toastr.error(loopErrorMsg, "Failed");

        newPaintDetails = JSON.stringify({ 'newPaintDetails': newPaintDetails });
        showWaitBlock();
        $.ajax({
            processData: false,
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            type: "POST",
            url: action,
            data: newPaintDetails,

            success: function (result) {
                hideWaitBlock();
                showToastr(result);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                toastr.error("ajax error block", "ajax error block");
            }
        });
    });
});