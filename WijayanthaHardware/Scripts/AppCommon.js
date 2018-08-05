function showToastr(data) {

    var message = null;

    if (data.status == "success") {
        toastr.success(data.message, data.title);

    }

    else if (data.status = "error") {
        toastr.error(data.message, data.title);

    }

    else if (data.status == "info") {
        toastr.info(data.message, data.title);
    }

    else {
        toastr.warning(data.message, data.title);
    }
}

function showWaitBlock() {
    $.blockUI({
        css: {
            width: 'unset',
            border: 'none',
            left: '50%',
            top: '50%',
            transform: 'translate(-50%,-50%)',
            backgroundColor: 'none'
        },
        overlayCSS: { backgroundColor: 'rgb(175, 169, 169)' },
        message: '<div class="loader"><div class="dot dot1"></div><div class="dot dot2"></div><div class="dot dot3"></div><div class="dot dot4"></div></div>',
        baseZ: 50000
    });
}

function hideWaitBlock() {
    $.unblockUI();
}

$(function () {

    $(document).on("click", '.btn-load-inner-form-modal-edit', function (e) {
        e.preventDefault();
        var link = $(this);
        var url = link.prop('href');
        $("#markup").load(url, function () {
            $('#innerFormModal').modal('show');
        });
    });
});