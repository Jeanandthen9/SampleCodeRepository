$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
    },
    // insert message next to lable/text box!
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            //checks is there any inputs within div/parent?
            // insert span AFTER input!
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});