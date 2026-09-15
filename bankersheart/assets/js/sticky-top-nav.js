
{
    window.onscroll = function () { myFunction() };

    var navbar = document.getElementById("navbar");
    var sticky = navbar.offsetTop;

    function myFunction() {
        if (window.pageYOffset >= sticky) {
            navbar.classList.add("sticky")
        } else {
            navbar.classList.remove("sticky");
        }
    }
}
{
    var current_url = window.location.pathname.substring(window.location.pathname.lastIndexOf('/') + 1);
    $("#mynavbar li.menu-item-has-children a  ").each(function () {
        if (current_url === $(this).attr('href').substring($(this).attr('href').lastIndexOf('/') + 1)) {
            $(this).parent().siblings("a").removeClass("active")
            $(this).addClass('active');
        }
        if (current_url === $(".sub_menu_parent a").attr('href').substring($(this).attr('href').lastIndexOf('/') + 1)) {
            $(this).parent().find('ul:first').slideToggle(300);
        }
    });
    // var mobileItems = $('#mynavbar ');
    // mobileItems.find('li.menu-item-has-children').append('<i class="mobile-arrows fa fa-plus"></i>');
    // $("#mynavbar  li.menu-item-has-children i.mobile-arrows").click(function () {
    //     if ($(this).hasClass("fa-plus"))
    //         $(this).removeClass("fa-plus").addClass("fa-minus");
    //     else
    //         $(this).removeClass("fa-minus").addClass("fa-plus");

    //     $(this).parent().find('ul:first').slideToggle(300);

    //     $(this).parent().find('> .mobile-arrows').toggleClass('is-open');
    // });
    

$("#mynavbar .dropdown-menu").hide()
    var mobileItems = $('#mynavbar ');
    mobileItems.find('li.menu-item-has-children').append('<i class=" mobile-arrows fa fa-angle-down"></i>');
    $("#mynavbar li.menu-item-has-children .nav-link,#mynavbar  li.menu-item-has-children i.mobile-arrows").click(function () {
        if ($("#mynavbar  li.menu-item-has-children i.mobile-arrows").hasClass("fa-angle-down"))
        $("#mynavbar  li.menu-item-has-children i.mobile-arrows").removeClass("fa-angle-up").addClass("fa-angle-down");
        else
        $("#mynavbar  li.menu-item-has-children i.mobile-arrows").removeClass("fa-angle-up").addClass("fa-angle-down");
        $("#mynavbar  li.menu-item-has-children i.mobile-arrows").parent().find('ul:first').slideToggle(300);
        $("#mynavbar  li.menu-item-has-children i.mobile-arrows").parent().find('> .mobile-arrows').toggleClass('is-open');
    });
    
}
