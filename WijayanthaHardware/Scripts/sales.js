$("#newpaintsale").click(function () {
    event.preventDefault();
    var $paint = $('<div class="row"><div class="piant-details"><div class= "col-xs-6 col-sm-6 col-md-3" ><label class="small-heading">Paint category</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div ><div class="col-xs-6 col-sm-6 col-md-3"><label class="small-heading">Paint</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div><div class="col-xs-6 col-sm-6 col-md-3"><label class="small-heading">Volume</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div><div class="col-xs-6 col-sm-6 col-md-3"><label class="small-heading">Quantity</label><input type="text" name="name" value="" placeholder="Quantity" /></div></div ></div >');
    $(".sales-point .paintsales").append($paint);
    $('select').niceSelect();
});

$("#newpowersale").click(function () {
    event.preventDefault();
    var $tool = $('<div class="row"><div class= "tools-details" ><div class="col-xs-6 col-sm-6 col-md-6"><label class="small-heading">Tool Category</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div><div class="col-xs-6 col-sm-6 col-md-6"><label class="small-heading">Tool</label><select class="wide"><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option><option value="value">text</option></select></div></div ></div >');
    $(".sales-point .power-sales").append($tool);
    $('select').niceSelect();
});