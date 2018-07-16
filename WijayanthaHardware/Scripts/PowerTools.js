$(document).ready(function () {


    $('#first').click(function () {
        var maincat = $('input[name="PowerToolId"]').attr('value');

        if (maincat != -1) {
            $.ajax({
                type: "GET",
                url: "/PowerTools/GetPaintSubCategories?paintCat=" + maincat,
                success: function (data) {
                    var subDepartment = $('#PowerToolSubCategoryId');
                    subDepartment.empty().append('<option value=""></option>');
                    $.each(data, function () {
                        subDepartment.append($('<option value="' + this.SubDepartmentId + '">' + this.Value + '</option>'));
                    });


                }
            });
        }
    });
});

