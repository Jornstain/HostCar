$(document).ready(function () {
    $('#adress').attr('disavled', false);
    LoadAdress();


});

function LoadAdress() {
    $('#adress').empty();
    $.ajax({
        url: '/Rent/GetAdress',
        success: function (response) {
            if (response != null && response != undefined) {
                $('#adress').attr('disavled', false);
                $('#adress').append('<option>Select Adress</option>');
                $.each(response, function (i, data) {
                    $('#adress').append('<option value=' + data.Id + '>' + data.OficeAdress + '</option>');
                });
            }
            else {
                $('#adress').attr('disavled', true);
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}