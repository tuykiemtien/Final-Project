$(document).ready(function () {
    $('#next').click(function (e) {
        e.preventDefault();
        let customer = {};
        customer.CompanyName = $('#company-name').val();
        customer.ContactName = $('#name').val();
        customer.ContactTitle = $('#title').val();
        customer.Address = $('#company-address').val();
        customer.City = $('#city').val();
        customer.Region = $('#region').val();
        customer.PostCode = $('#post-code').val();
        customer.Country = $('#country').val();
        customer.Phone = $('#phone').val();
        customer.Fax = $('#fax').val();
        let check = true;
        if (customer.CompanyName == '')
        {
            check = false;
            $('#company-name-valid').text('This field can not empty');
        }
        else
        {
            $('#company-name-valid').text('');
        }
        if (customer.ContactName == '') {
            check = false;
            $('#name-valid').text('This field can not empty');
        }
        else {
            $('#name-valid').text('');
        }
        if (customer.Address == '') {
            check = false;
            $('#company-address-valid').text('This field can not empty');
        }
        else {
            $('#company-address-valid').text('');
        }
        if (customer.City == '') {
            check = false;
            $('#city-valid').text('This field can not empty');
        }
        else {
            $('#city-valid').text('');
        }
        if (customer.Phone != '') {
            if (!validPhone(customer.Phone))
            {
                check = false;
                $('#phone-valid').text('Phone not correct.(123) 456-7890 ||'+
                    '(123)456-7890 ||' +
                    ' 123-456-7890 ||'+
                    ' 123.456.7890 ||'+
                    ' 1234567890 ||'+
                    ' 31636363634 ||'+
                    ' 075-63546725');
            }
            else
            {
                $('#phone-valid').text('');
            }
        }
        if (customer.Fax != '') {
            if (!validPhone(customer.Fax)) {
                check = false;
                $('#fax-valid').text('Fax not correct.(123) 456-7890 ||' +
                    '(123)456-7890 ||' +
                    ' 123-456-7890 ||' +
                    ' 123.456.7890 ||' +
                    ' 1234567890 ||' +
                    ' 31636363634 ||' +
                    ' 075-63546725');
            }
            else {
                $('#fax-valid').text('');
            }
        }

        if (check) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '/Home/Customer',
                data: '{customer: ' + JSON.stringify(customer) + '}',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.Ok) {
                        window.location = '/Index/Index'
                    }
                    else {
                        $('#finish-valid').text('Invalid input');
                    }
                },
                error: function () {
                    $('#finish-valid').text('server error');
                }
            })
        }
        
    });
    function validPhone(phone) {
        let regex = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/;
        return regex.test(phone);
    }
})