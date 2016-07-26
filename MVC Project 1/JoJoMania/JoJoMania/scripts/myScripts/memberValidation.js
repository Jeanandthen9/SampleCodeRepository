$(document)
    .ready(function () {
        $('#memberForm')
            .validate({
                rules: {
                    'Member.UserName': {
                        required: true,
                        minlength: 5,
                        maxlength: 15,
                        alphanumeric: true,
                        nowhitespace: true
                    },
                    'Member.Age': {
                        required: true,
                        minlength: 2,
                        maxlength: 2
                    },
                    'Member.FavJoJo.ID': {
                        required: true
                    },
                    'Member.FavPart.PartNumber': {
                        required: true
                    }
                },
                // LET'S ADD MESSAGES!
                messages: {
                    UserName: {
                        required: "Please enter your username! Do not leave this blank!",
                        minlength: "Your username must be at least 5 characters long!",
                        maxlength: "Your username cannot exceed 15 characters!"
                    },
                    Age: {
                        required: "Please enter your age! Do not leave this blank!",
                        minlength: "You're too young to be using this site! Sorry!",
                        maxlength: "You're too old to be using this site! Sorry!"
                    },
                    FavJoJo: "You HAVE to select your favorite JoJo!",
                    FavPart: "You HAVE to choose your favorite part in the JoJo series!"
                }
            });
    });