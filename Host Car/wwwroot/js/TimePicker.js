$(function () {
    $('.timepicker').timepicker({
        timeFormat: 'h:mm p',
        interval: 60,
        minTime: '09:00',
        maxTime: '8:00pm',
        defaultTime: '09:00',
        startTime: '09:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true
    });

});