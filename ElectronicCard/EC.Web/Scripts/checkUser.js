$(document).ready(function () {
    $("#IsDoctor").change(function () {
        if ($(this).prop('checked')) {
            $('#position').fadeIn(300);
            $('#hidePatient').fadeIn(300);
            $('#PlaceWork').fadeOut().show();
            $('#DateBirth').fadeOut().show();
            $('#hideDoctors').fadeOut().show();
        } else {
            $('#position').fadeOut().show();
            $('#hidePatient').fadeOut().show();
            $('#hideDoctors').fadeOut().show();
            $('#PlaceWork').fadeIn(300);
            $('#DateBirth').fadeIn(300);
        }
    });
})