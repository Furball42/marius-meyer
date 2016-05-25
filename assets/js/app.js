$(document).ready(function () {

    $("#contactForm").submit(function () {
        event.preventDefault();

        var email = $('#email').val();
        var name = $('#name').val();
        var message = $('#message').val();

        sendMail(email, name, message);

        return false;
    });

});


var sendMail = function (email, name, message) {
    $.ajax({
        type: 'post',
        url: 'mail.asmx/SendMail',
        data: {
            sEmail: email,
            sName: name,
            sMessage: message
        },
        success: function (data) {
            var obj = data.d;
           
            $('#email').val('');
            $('#name').val('');
            $('#message').val('');
        }
    });
}