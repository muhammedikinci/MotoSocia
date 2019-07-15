function initializer() {
    createNewUserListener();
}

function createNewUserListener() {
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

export default initializer;