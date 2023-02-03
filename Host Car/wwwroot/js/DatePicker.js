$(function () {
        $('.datepicker').datepicker(
            {
                dateFormat: 'yy-mm-dd',
                minDate: new Date(),
                maxDate: AddSubstractMonth(new Date(), 3)
            }
    );
    function AddSubstractMonth(date, numMonths) {
        var month = date.getMonth();
        var milliSeconds = new Date(date).setMonth(month + numMonths);
        return new Date(milliSeconds);
    }

        });