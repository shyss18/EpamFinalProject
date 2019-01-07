$(document).ready(function () {
    $("#IsDoctor").change(function () {
        if ($(this).prop('checked')) {
            $('#Position').fadeIn(300);
            $('#hidePatient').fadeIn(300);
            $('#PlaceWork').fadeOut().show();
            $('#DateBirth').fadeOut().show();
            $('#hideDoctors').fadeOut().show();
        } else {
            $('#Position').fadeOut().show();
            $('#hidePatient').fadeOut().show();
            $('#hideDoctors').fadeIn(300);
            $('#PlaceWork').fadeIn(300);
            $('#DateBirth').fadeIn(300);
        }
    });
})