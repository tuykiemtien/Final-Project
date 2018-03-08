$(document).ready(function () {

    //hàm xử lý đăng ký
    $('#register').click(function (event) {
        event.preventDefault();
        let account = {};
        account.Username = $('#username').val();
        account.Password = $('#password').val();
        account.Email = $('#email').val();
        let confirmPassword = $('#confirm-password').val();
        let check = true;
        let customer = {};       
        if (account.Username == '')
        {
            check = false;
            $('#username-valid').text('The field cannot empty');
        }
        else
        {
            $('#username-valid').text('');
        }
        if (account.Password == '')
        {
            check = false;
            $('#password-valid').text('The field cannot empty');
        }
        else
        {
            $('#password-valid').text('');
        }
        if (confirmPassword == '')
        {
            check = false;
            $('#confirm-password-valid').text('The field cannot empty');
        }
        else
        {
            if (confirmPassword != account.Password)
            {
                check = false;
                $('#confirm-password-valid').text('Confirm password must same password');
            }
            else
            {
                $('#confirm-password-valid').text('');
            }
        }
        if (account.Email == '') {
            check = false;
            $('#email-valid').text('The field cannot empty');
        }
        else {
            if (validateEmail(account.Email)) {
                $('#email-valid').text('');
            }
            else {
                check = false;
                $('#email-valid').text('Email not correct');
            }
        }
        if (check) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '/Home/Register',
                data: '{account: ' + JSON.stringify(account) + '}',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.Ok) {
                        window.location = '/Home/About'
                    }
                    else {
                        $('#register-valid').text('Username exits');
                    }
                },
                error: function () {
                    $('#register-valid').text('server error');
                }
            })
        }
        
    });


    //hàm xử lý login
    $('#login').click(function (event) {
        event.preventDefault();
        let account = {};
        account.Username = $('#login-username').val();
        account.Password = $('#login-password').val();
        let check = true;
        if (account.Username == '') {
            check = false;
            $('#login-username-valid').text('The field cannot empty');
        }
        else {
            $('#login-username-valid').text('');
        }
        if (account.Password == '') {
            check = false;
            $('#login-password-valid').text('The field cannot empty');
        }
        else {
            $('#login-password-valid').text('');
        }
        if (check) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '/Home/Login',
                data: '{account: ' + JSON.stringify(account) + '}',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    switch (data.Ok) {
                        case 'error':
                            $('#login-valid').text('Invalid username or password');
                            break;
                        case 'employee':
                            window.location = '/Admin/Order/Index';
                            break;
                        case 'finish':
                            window.location = '/Index/Index';
                            break;
                        case 'not finish':
                            window.location = '/Home/About';
                            break;
                    }
                },
                error: function () {
                    $('#login-valid').text('server error');
                }
            })
        }
    })


    //hàm kiểm tra định dạng email
    function validateEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }
})