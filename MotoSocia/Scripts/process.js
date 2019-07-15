function initializer() {
    createNewUserListener();
    loginUserListener();
}

function createNewUserListener() {
    if ($('#newuserform').length > 0) {
        $('#newuserform').parsley().on('field:validated', function () {
            var ok = $('.parsley-error').length === 0;
            $('.bs-callout-info').toggleClass('hidden', !ok);
            $('.bs-callout-warning').toggleClass('hidden', ok);
        });

        $('#newuserbutton').on('click', function () {
            if ($('#newuserform').parsley().validate() && $('.parsley-error').length === 0) {
                $('#newuserform').submit();
            }
        });
    }
}

function loginUserListener() {
    if ($('#loginuserform').length > 0) {
        $('#loginuserform').parsley().on('field:validated', function () {
            var ok = $('.parsley-error').length === 0;
            $('.bs-callout-info').toggleClass('hidden', !ok);
            $('.bs-callout-warning').toggleClass('hidden', ok);
        });

        $('#loginuserbutton').on('click', function () {
            if ($('#loginuserform').parsley().validate() && $('.parsley-error').length === 0) {
                $('#loginuserform').submit();
            }
        });
    }
}

export default initializer;