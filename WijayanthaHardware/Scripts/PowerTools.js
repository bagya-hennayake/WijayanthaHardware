$(document).ready(function () {


    $('#first').click(function () {
        var maincat = $('input[name="PowerToolId"]').attr('value');

        if (maincat != -1) {
            $.ajax({
                type: "GET",
                url: "/PowerTools/GetPaintSubCategories?departmentId=" + $(this).val(),
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

