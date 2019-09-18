$(document).ready(function () {

    // put all your jQuery goodness in here.
    $('#media-apple').hover(function () {
        $(this).hide();
        $('#media-apple-ref').show();
    });

    $('#media-apple-ref').mouseout(function () {
        $(this).hide();
        $('#media-apple').show();
    });

    $('#media-bbb').hover(function () {
        $(this).hide();
        $('#media-bbb-ref').show();
    });

    $('#media-bbb-ref').mouseout(function () {
        $(this).hide();
        $('#media-bbb').show();
    });

    $('#media-NewYork').hover(function () {
        $(this).hide();
        $('#media-NewYork-ref').show();
    });

    $('#media-NewYork-ref').mouseout(function () {
        $(this).hide();
        $('#media-NewYork').show();
    });

    $('#media-cnn').hover(function () {
        $(this).hide();
        $('#media-cnn-ref').show();
    });

    $('#media-cnn-ref').mouseout(function () {
        $(this).hide();
        $('#media-cnn').show();
    });

    $('#media-rss').hover(function () {
        $(this).hide();
        $('#media-rss-ref').show();
    });

    $('#media-rss-ref').mouseout(function () {
        $(this).hide();
        $('#media-rss').show();
    });

    $('#media-google').hover(function () {
        $(this).hide();
        $('#media-google-ref').show();
    });

    $('#media-google-ref').mouseout(function () {
        $(this).hide();
        $('#media-google').show();
    });

    $('#media-twitter').hover(function () {
        $(this).hide();
        $('#media-twitter-ref').show();
    });

    $('#media-twitter-ref').mouseout(function () {
        $(this).hide();
        $('#media-twitter').show();
    });

    $('#media-facebook').hover(function () {
        $(this).hide();
        $('#media-facebook-ref').show();
    });

    $('#media-facebook-ref').mouseout(function () {
        $(this).hide();
        $('#media-facebook').show();
    });

    $('#media-linkedin').hover(function () {
        $(this).hide();
        $('#media-linkedin-ref').show();
    });

    $('#media-linkedin-ref').mouseout(function () {
        $(this).hide();
        $('#media-linkedin').show();
    });

    $('#media-linkin').hover(function () {
        $(this).hide();
        $('#media-linkin-ref').show();
    });

    $('#media-linkin-ref').mouseout(function () {
        $(this).hide();
        $('#media-linkin').show();
    });

    $('#media-msn').hover(function () {
        $(this).hide();
        $('#media-msn-ref').show();
    });

    $('#media-msn-ref').mouseout(function () {
        $(this).hide();
        $('#media-msn').show();
    });

    $('#btn-merchantApp').hover(function () {
        $(this).hide();
        $('#btn-merchantApp-ref').show();
    });

    $('#btn-merchantApp-ref').mouseout(function () {
        $(this).hide();
        $('#btn-merchantApp').show();
    });

    $("#btn-submit").hover(function () {
        $(this).hide();
        $('#btn-submit-ref').show();   
    });

    $("#btn-submit-ref").mouseout(function () {
        $(this).hide();
        $('#btn-submit').show();        
    });

    $("#login").hover(function () {
        $(this).hide();
        $('#login-ref').show();
    });

    $("#login-ref").mouseout(function () {
        $(this).hide();
        $('#login').show();
    });


    $("#faketxtUserID").focus(function () {

        $((this)).hide();
        $('#txtUserID').show().focus();

    });

    $("#faketxtUserID").mouseover(function () {

        $((this)).val('');

    });

    $("#faketxtUserID").mouseout(function () {

        $((this)).val('username');

    });

    $("#txtUserID").blur(function () {

        if ($((this)).attr('value') == '') {

            $((this)).hide();
            $('#faketxtUserID').show();

        }

    });

    $("#faketxtPwd").focus(function () {

        $((this)).hide();
        $('#txtPwd').show().focus();

    });

    $("#faketxtPwd").mouseover(function () {

        $((this)).val('');

    });

    $("#faketxtPwd").mouseout(function () {

        $((this)).val('password');

    });

    $("#txtPwd").blur(function () {

        if ($((this)).attr('value') == '') {

            $((this)).hide();
            $('#faketxtPwd').show();

        }
    });





    $("#fakeName").focus(function () {

        $((this)).hide();
        $('#Name').show().focus();

    });

    $("#fakeName").mouseover(function () {

        $((this)).val('');

    });

    $("#fakeName").mouseout(function () {

        $((this)).val('Contact Name');

    });

    $("#Name").blur(function () {

        if ($((this)).attr('value') == '') {

            $((this)).hide();
            $('#fakeName').show();

        }

    });


    $("#fakeBusinessName").focus(function () {

        $((this)).hide();
        $('#BusinessName').show().focus();

    });

    $("#fakeBusinessName").mouseover(function () {

        $((this)).val('');

    });

    $("#fakeBusinessName").mouseout(function () {

        $((this)).val('Business Name');

    });

    $("#BusinessName").blur(function () {

        if ($((this)).attr('value') == '') {

            $((this)).hide();
            $('#fakeBusinessName').show();

        }

    });


    $("#fakePhoneNumber").focus(function () {

        $((this)).hide();
        $('#PhoneNumber').show().focus();

    });

    $("#fakePhoneNumber").mouseover(function () {

        $((this)).val('');

    });

    $("#fakePhoneNumber").mouseout(function () {

        $((this)).val('Phone Number');

    });

    $("#PhoneNumber").blur(function () {

        if ($((this)).attr('value') == '') {

            $((this)).hide();
            $('#fakePhoneNumber').show();

        }

    });

    $("#fakeEmailAddress").focus(function () {

        $((this)).hide();
        $('#EmailAddress').show().focus();

    });

    $("#fakeEmailAddress").mouseover(function () {

        $((this)).val('');

    });

    $("#fakeEmailAddress").mouseout(function () {

        $((this)).val('E-Mail Address');

    });

    $("#EmailAddress").blur(function () {

        if ($((this)).attr('value') == '') {

            $((this)).hide();
            $('#fakeEmailAddress').show();

        }
    });

    $("#loginForm").submit(function () {

        if ($(this).valid()) {
            // alert("true");
            return true;
        }

        //alert("false");
        $("#faketxtUserID").css({ "border": "1px solid red", "width":"203px", "height": "18px" });
        $("#faketxtPwd").css({ "border": "1px solid red", "width":"203px", "height": "18px"});
        return false;
    });

});