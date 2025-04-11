$(document).ready(function () {
    $('#menu-toggle').click(function (e) {
        e.preventDefault(); // Prevent default link behavior

        // If sidebar is hidden, show it; otherwise, toggle active class
        if ($('#side-nav').is(':hidden')) {
            $('#side-nav').fadeIn();
        } else {
            $('#side-nav').toggleClass('active');
        }
    });

    let lastScrollTop = 0; // Store previous scroll position

    $(window).scroll(function () {
        let currentScroll = $(this).scrollTop();

        if (currentScroll > lastScrollTop) {
            // Scrolling down -> Hide sidebar
            $('#side-nav').fadeOut();
        }

        lastScrollTop = currentScroll;
    });
});

//validation for add class
$(document).ready(function () {
    $(".btn-AddClass").click(function () {
        var element = $(".txt-AddClass");
        if (element.val().trim() === "") {
            $(".msg-validation").show();
            return false;
        }
        else {
            $(".msg-validation").hide();
        }
    });
});

//validations for add student and add teacher
$(document).ready(function () {

    let isValid = 1;
    $(".btn-add").click(function (e) {

        let name = $(".txt-name");

        if (name.val().trim() === "") {
            $(".msg-validation-name").show();
            name.focus();
            isValid = 0;
        } else {
            $(".msg-validation-name").hide();
        }

        let dob = $(".txt-dob").val().trim();

        if (dob === "") {
            $(".msg-validation-dob").show();
            $(".txt-dob").focus();
            isValid = 0;
        }
        else {
            dob = new Date(dob);
            let today = new Date();
            let age = today.getFullYear() - dob.getFullYear();
            if (age < 18) {
                $(".msg-validation-dob").text("Should be atleast 18 years old").show();
                $(".txt-dob").focus();
                isValid = 0;
            }
            else {
                $(".msg-validation-dob").hide();
            }
        }

        let mobile = $(".txt-mobile").val().trim();

        if (mobile.length < 10) {
            $(".msg-validation-mobile").show();
            $(".txt-mobile").focus();
            isValid = 0;
        } else {
            $(".msg-validation-mobile").hide();
        }

        let email = $(".txt-email").val().trim();
        const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        if (!emailPattern.test(email)) {
            $(".msg-validation-email").show();
            $(".txt-email").focus();
            isValid = 0;
        } else {
            $(".msg-validation-email").hide();
        }

        let password = $(".txt-password").val().trim();
        const passwordPattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/;

        if (!passwordPattern.test(password)) {
            $(".msg-validation-password").show();
            $(".txt-password").focus();
            isValid = 0;
        } else {
            $(".msg-validation-password").hide();
        }

        if (isValid == 0) {
            e.preventDefault();
            return false;
        }

    });
});

//validations for signUp
$(document).ready(function () {

    $(".btn-register").click(function () {

        let email = $(".txt-email").val().trim();
        const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        if (!emailPattern.test(email)) {
            $(".msg-validation-email").show();
            $(".txt-email").focus();
            return false;
        } else {
            $(".msg-validation-email").hide();
        }

        let password = $(".txt-password").val().trim();
        const passwordPattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/;

        if (!passwordPattern.test(password)) {
            $(".msg-validation-password").show();
            $(".txt-password").focus();
            return false;
        } else {
            $(".msg-validation-password").hide();
        }

        let rePassword = $(".txt-rePassword").val().trim();

        if (!passwordPattern.test(rePassword)) {
            $(".msg-validation-rePassword").show();
            $(".txt-rePassword").focus();
            return false;
        } else {
            $(".msg-validation-rePassword").hide();
        }

        if (password !== rePassword) {
            $(".msg-validation-rePassword").text("Passwords do not match!").show();
            $(".txt-rePassword").focus();
            return false;
        } else {
            $(".msg-validation-rePassword").hide();
        }

    });

});

//validations for login page
$(document).ready(function () {
    $("#btnLogin").click(function (e) {
        let email = $("#txtEmail").val().trim();
        let password = $("#txtPassword").val().trim();
        let isValid = 1;
        if (email === "") {
            $(".msg-validation-email").show();
            isValid = 0;
        }
        else {
            $(".msg-validation-email").hide();
            isValid = 1;
        }
        if (password === "") {
            $(".msg-validation-password").show();
            isValid = 0;
        }
        else {
            $(".msg-validation-password").hide();
            isValid = 1;
        }
        if (isValid === 0) {
            return false;
        }
    });
});
