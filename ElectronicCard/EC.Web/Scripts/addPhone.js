var i = 0;

$('#extraFieldAdd').click(function (event) {

    i++;
    addNewPhoneField();
    return false;
});

function addNewPhoneField() {

    var div = $('<div/>',
        {
            'class': 'ExtraPhones'
        }).appendTo($('#ExtraPhonesContainer'));

    var input = $('<input/>',
        {
            id: 'Phones',
            name: 'Phones[' + i + '].PhoneNumber',
            placeholder: 'Номер телефона',
            required: 'True',
            'class': 'form-control',
            type: 'text'
        }).appendTo(div);

    var extra = $('<input/>',
        {
            value: 'Убрать номер',
            type: 'button',
            'class': 'btn btn-sm btn-danger col-sm-5'
        }).appendTo(div);

    $('<br/>').insertAfter(input);
    $('<br/>').insertAfter(div);

    extra.click(function () {
        $(this).parent().remove();
        $(br).remove();
    });
};