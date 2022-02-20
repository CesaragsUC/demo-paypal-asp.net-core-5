﻿$(document).ready(function () {

    // botão de desabilitar se a senha não for regular
    $('#reg_userpassword').keyup(function () {
        var password = $('#reg_userpassword').val();
        var confirmpassword = $('#reg_userpasswordconfirm').val();

        if (checkStrength(password) == false) {
            $('#reg_submit').attr('disabled', true);
        }
    });

    // divi regra de senha ocultar / mostrar
    $('#reg_userpassword').keyup(function () {
        if ($('#reg_userpassword').val()) {
            $('#reg_passwordrules').removeClass('hide');
            $('#reg-password-strength').removeClass('hide');
        } else {
            $('#reg_passwordrules').addClass('hide');
            $('#reg-password-quality').addClass('hide')
            $('#reg-password-quality-result').addClass('hide')
            $('#reg-password-strength').addClass('hide')

        }
    });

    // password-confirm error divi hide/show
    $('#reg_userpasswordconfirm').blur(function () {
        if ($('#reg_userpassword').val() !== $('#reg_userpasswordconfirm').val()) {
            $('#error-confirmpassword').removeClass('hide');
            $('#reg_submit').attr('disabled', true);
        } else {
            $('#error-confirmpassword').addClass('hide');
            $('#reg_submit').attr('disabled', false);
        }
    });


    $('#reg_submit').hover(function () {
        if ($('#reg_submit').prop('disabled')) {
            $('#reg_submit').popover({
                html: true,
                trigger: 'hover',
                placement: 'below',
                offset: 20,
                content: function () {
                    return $('#sign-up-popover').html();
                }
            });
        }
    });
    // validação de personagem
    function checkStrength(password) {
        var strength = 0;

        //If password contains both lower and uppercase characters, increase strength value.
        if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) {
            strength += 1;
            $('.low-upper-case').addClass('text-success');
            $('.low-upper-case i').removeClass('fa-check').addClass('fa-check');
            $('#reg-password-quality').addClass('hide');


        } else {
            $('.low-upper-case').removeClass('text-success');
            $('.low-upper-case i').addClass('fa-check').removeClass('fa-check');
            $('#reg-password-quality').removeClass('hide');
        }

        //If it has numbers and characters, increase strength value.
        if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) {
            strength += 1;
            $('.one-number').addClass('text-success');
            $('.one-number i').removeClass('fa-check').addClass('fa-check');
            $('#reg-password-quality').addClass('hide');

        } else {
            $('.one-number').removeClass('text-success');
            $('.one-number i').addClass('fa-check').removeClass('fa-check');
            $('#reg-password-quality').removeClass('hide');
        }

        //If it has one special character, increase strength value.
        //need to use @@ rather 1 'at' to validate special caracter in razor pages
        if (password.match(/([!,%,&,@@,#,$,^,*,?,_,~])/)) {
            strength += 1;
            $('.one-special-char').addClass('text-success');
            $('.one-special-char i').removeClass('fa-check').addClass('fa-check');
            $('#reg-password-quality').addClass('hide');

        } else {
            $('.one-special-char').removeClass('text-success');
            $('.one-special-char i').addClass('fa-check').removeClass('fa-check');
            $('#reg-password-quality').removeClass('hide');
        }

        if (password.length > 7) {
            strength += 1;
            $('.eight-character').addClass('text-success');
            $('.eight-character i').removeClass('fa-check').addClass('fa-check');
            $('#reg-password-quality').removeClass('hide');

        } else {
            $('.eight-character').removeClass('text-success');
            $('.eight-character i').addClass('fa-check').removeClass('fa-check');
            $('#reg-password-quality').removeClass('hide');
        }
        // ------------------------------------------------------------------------------
        // If value is less than 2
        if (strength < 2) {
            $('#reg-password-quality-result').removeClass()
            $('#password-strength').addClass('progress-bar-danger');

            $('#reg-password-quality-result').addClass('text-danger').text('Weak');
            $('#password-strength').css('width', '10%');
        } else if (strength == 2) {
            $('#reg-password-quality-result').addClass('good');
            $('#password-strength').removeClass('progress-bar-danger');
            $('#password-strength').addClass('progress-bar-warning');
            $('#reg-password-quality-result').addClass('text-warning').text('Medium')
            $('#password-strength').css('width', '60%');
            return 'Week'
        } else if (strength == 4) {
            $('#reg-password-quality-result').removeClass()
            $('#reg-password-quality-result').addClass('strong');
            $('#password-strength').removeClass('progress-bar-warning');
            $('#password-strength').addClass('progress-bar-success');
            $('#reg-password-quality-result').addClass('text-success').text('Strong');
            $('#password-strength').css('width', '100%');

            return 'Strong'
        }

    }


});

// Mostrar esconder senha
function togglePassword() {

    var element = document.getElementById('reg_userpassword');
    element.type = (element.type == 'password' ? 'text' : 'password');

};