var formsDataToBeValidation = [
    {
        "buttonSelector": "#newuserbutton",
        "formSelector": "#newuserform"
    },
    {
        "buttonSelector": "#loginuserbutton",
        "formSelector": "#loginuserform"
    }
];

formsDataToBeValidation.forEach((formData) => {
    if ($(formData.formSelector).length > 0) {
        $(formData.formSelector).parsley().on('field:validated', function () {
            var ok = $('.parsley-error').length === 0;
            $('.bs-callout-info').toggleClass('hidden', !ok);
            $('.bs-callout-warning').toggleClass('hidden', ok);
        });

        $(formData.buttonSelector).on('click', function () {
            if ($(formData.formSelector).parsley().validate() && $('.parsley-error').length === 0) {
                $(formData.formSelector).submit();
            }
        });
    }
});