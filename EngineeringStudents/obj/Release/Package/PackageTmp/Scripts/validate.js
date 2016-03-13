
// validate contact form
$(function () {
  
    $('#contact').validate({
        rules: {
            txtName: {
                required: true,
                myfileld:true
            },
            txtEmail: {
                required: true,
                email: true
            },
            phnnumber: {
                required: true,
                digits: true,
                minlength: 10
            },
            txtSubject: {
                required: true
            },
            txtMessage: {
                required: true
            }
        },
      
        messages: {
            txtName: {
                required: "Please Enter Your Name"
               
            },
            txtEmail: {
                required: "You have entered an invalid email address!"
            },
            phnnumber: {
                required: "This field is required",
                digits: "This field can only contain numbers",
                minlength: "This field must contain at least 10 characters"
            },
            txtSubject: {
                required: "This field is required"
            },
            txtMessage: {
                required: "um...yea, you have to write something to send this form."
            }
        },

        submitHandler: function(form) {
            $(form).ajaxSubmit({
                type:"POST",
                data: $(form).serialize(),
                url: "contactus.php",
                success: function() {
                    $('#success').fadeIn();
                    setTimeout(function () { $('#success').fadeOut('slow'); }, 3000);
                },
                error: function() {
                    $('#error').fadeIn();
                    setTimeout(function () { $('#error').fadeOut('slow'); }, 3000);
                }
            });
            $('#contact').trigger('reset');
        }
    });

    jQuery.validator.addMethod("myfileld", function (value, element) {
        return this.optional(element) || /^[a-z," "]+$/i.test(value);
    }, "Accept Only Alphabets");
});