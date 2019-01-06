$(document).ready(function () {
    $("#IsDoctor").change(function () {
        if ($(this).prop('checked')) {
            $('#Position').fadeIn(300);
            $('#PlaceWork').fadeOut().show();
            $('#DateBirth').fadeOut().show();
        } else {
            $('#Position').fadeOut().show();
            $('#PlaceWork').fadeIn(300);
            $('#DateBirth').fadeIn(300);
        }
    });
})