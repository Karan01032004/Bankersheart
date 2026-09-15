$(function () {
    $("#application-accordian .accordion_content").hide();
    $('#application-accordian .accordion_toggle').first().next("#application-accordian .accordion_content").slideDown(500);
    $('#application-accordian .accordion_toggle').first().addClass("accordion_toggle_active");
    $("#application-accordian .accordion_toggle").click(function () {
        if ($(this).hasClass("accordion_toggle_active")) {
            $(this).next("#application-accordian .accordion_content").slideToggle(500);
            $(this).toggleClass("accordion_toggle_active");
        } else {
            $("#application-accordian .accordion_toggle.accordion_toggle_active").next("#application-accordian .accordion_content").slideUp(500);
            $("#application-accordian .accordion_toggle.accordion_toggle_active").removeClass("accordion_toggle_active");
            $(this).next("#application-accordian .accordion_content").slideDown(500);
            $(this).addClass("accordion_toggle_active");
        }
    });
});


$(".ecom").hide();
$(".cap").hide();
$(".sus").hide();
$(".sup").hide();
$(".food").hide();
$("#application-accordian").click(function () {
    if ($("#capabilities").hasClass("accordion_toggle_active")) {
        $(".cap").show();
        $(".ecom").hide();
        $(".sus").hide();
        $(".sup").hide();
        $(".food").hide();

    }
    if ($("#ecommerce").hasClass("accordion_toggle_active")) {
        $(".ecom").show();
        $(".cap").hide();
        $(".sus").hide();
        $(".sup").hide();
        $(".food").hide();
    }
    if ($("#supermart").hasClass("accordion_toggle_active")) {
        $(".sup").show();
        $(".ecom").hide();
        $(".cap").hide();
        $(".sus").hide();
        $(".food").hide();
    }
    if ($("#food").hasClass("accordion_toggle_active")) {
        $(".food").show();
        $(".sup").hide();
        $(".ecom").hide();
        $(".cap").hide();
        $(".sus").hide();
    }
    if ($("#sustainable").hasClass("accordion_toggle_active")) {
        $(".sus").show();
        $(".food").hide();
        $(".sup").hide();
        $(".ecom").hide();
        $(".cap").hide();
    }
});


//if ($("#ecommerce").hasClass("accordion_toggle")) {
//    $(".ecom").show();
//}
//if ($("#supermart").hasClass("accordion_toggle")) {
//    $(".sup").show();
//}
//if ($("#food").hasClass("accordion_toggle")) {
//    $(".food").show();
//}
//if ($("#sustainable").hasClass("accordion_toggle")) {
//    $(".sus").show();
//}

$("#click11").click(function () {
    $('html, body').animate({
        scrollTop: $("#die").offset().top - 90
    }, 500);
});
$("#click12").click(function () {
    $('html, body').animate({
        scrollTop: $("#patch").offset().top - 90
    }, 500);
});
$("#click13").click(function () {
    $('html, body').animate({
        scrollTop: $("#loop").offset().top - 90
    }, 500);
});
$("#click14").click(function () {
    $('html, body').animate({
        scrollTop: $("#sealable").offset().top - 90
    }, 500);
});
$("#click15").click(function () {
    $('html, body').animate({
        scrollTop: $("#tote").offset().top - 90
    }, 500);
});
$("#click16").click(function () {
    $('html, body').animate({
        scrollTop: $("#wave").offset().top - 90
    }, 500);
});


$("#click31").click(function () {
    $('html, body').animate({
        scrollTop: $("#flat").offset().top - 90
    }, 500);
});
$("#click32").click(function () {
    $('html, body').animate({
        scrollTop: $("#bubble").offset().top - 90
    }, 500);
});
$("#click33").click(function () {
    $('html, body').animate({
        scrollTop: $("#garment").offset().top - 90
    }, 500);
});
$("#click34").click(function () {
    $('html, body').animate({
        scrollTop: $("#labels").offset().top - 90
    }, 500);
});
$("#click35").click(function () {
    $('html, body').animate({
        scrollTop: $("#auto").offset().top - 90
    }, 500);
});



$("#click41").click(function () {
    $('html, body').animate({
        scrollTop: $("#tshirt").offset().top - 90
    }, 500);
});
$("#click42").click(function () {
    $('html, body').animate({
        scrollTop: $("#register").offset().top - 90
    }, 500);
});
$("#click43").click(function () {
    $('html, body').animate({
        scrollTop: $("#poly").offset().top - 90
    }, 500);
});
$("#click44").click(function () {
    $('html, body').animate({
        scrollTop: $("#produce").offset().top - 90
    }, 500);
});

$("#click51").click(function () {
    $('html, body').animate({
        scrollTop: $("#flexible").offset().top - 90
    }, 500);
});
$("#click52").click(function () {
    $('html, body').animate({
        scrollTop: $("#takeout").offset().top - 90
    }, 500);
});
$("#click53").click(function () {
    $('html, body').animate({
        scrollTop: $("#reclosable").offset().top - 90
    }, 500);
});
$("#click54").click(function () {
    $('html, body').animate({
        scrollTop: $("#wicketed").offset().top - 90
    }, 500);
});



$("#click61").click(function () {
    $('html, body').animate({
        scrollTop: $("#paper").offset().top - 90
    }, 500);
});
$("#click62").click(function () {
    $('html, body').animate({
        scrollTop: $("#bio").offset().top - 90
    }, 500);
});
$("#click63").click(function () {
    $('html, body').animate({
        scrollTop: $("#compos").offset().top - 90
    }, 500);
});
$("#click64").click(function () {
    $('html, body').animate({
        scrollTop: $("#reusable").offset().top - 90
    }, 500);
});
$("#click65").click(function () {
    $('html, body').animate({
        scrollTop: $("#natural").offset().top - 90
    }, 500);
});
$("#click66").click(function () {
    $('html, body').animate({
        scrollTop: $("#mesh").offset().top - 90
    }, 500);
});

window.onscroll = function () {

    if (window.pageYOffset > 100) {
        $("#application-accordian").css("position", "fixed");
    }
    if (window.pageYOffset <= 100) {
        $("#application-accordian").css("top", "20px");
        $("#application-accordian").fadeIn("slow");

    }

    if (window.pageYOffset > 46.5) {
        $(".navbar").addClass("navbar-fixed-top");
        $("#navigation .navbar-default").css("box-shadow", "0px 0px 10px #ccc");
    }
    if (window.pageYOffset <= 46.5) {
        $(".navbar").removeClass("navbar-fixed-top");
        $("#navigation .navbar-default").css("box-shadow", "none");
    }
}

