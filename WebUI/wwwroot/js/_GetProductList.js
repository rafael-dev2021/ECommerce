$(document).ready(function () {
    $('.showDetailModel').on('click', function () {
        const id = $(this).data('id');
        $('#showModal_' + id).modal('show');
    });
});


