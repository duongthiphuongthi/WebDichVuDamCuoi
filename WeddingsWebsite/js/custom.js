$(document).scroll(function () {
    var y = $(this).scrollTop();
    if (y > 200) {
        $("#btn-menu-mobile i").addClass("position-fixed bg-dark rounded shadow");
        $("#btn-menu-mobile i").css("top","10px")
    } else {
        $("#btn-menu-mobile i").removeClass("position-fixed bg-dark rounded shadow");
        $("#btn-menu-mobile i").css("top","0")
    }
});

$(function() {
    "use strict";

    $(".preloader").delay(1000).fadeOut();
    // this is for close icon when navigation open in mobile view
    $(".nav-toggler").on('click', function() {
        $("#main-wrapper").toggleClass("show-sidebar");
        
    });
    $(".search-box a, .search-box .app-search .srh-btn").on('click', function() {
        $(".app-search").toggle(200);
        $(".app-search input").focus();
    });

    // ============================================================== 
    // Resize all elements
    // ============================================================== 
    $("body, .page-wrapper").trigger("resize");
    $(".page-wrapper").delay(20).show();
    
    //****************************
    /* This is for the mini-sidebar if width is less then 1170*/
    //**************************** 
    var setsidebartype = function() {
        var width = (window.innerWidth > 0) ? window.innerWidth : this.screen.width;
        if (width < 1170) {
            $("#main-wrapper").attr("data-sidebartype", "mini-sidebar");
        } else {
            $("#main-wrapper").attr("data-sidebartype", "full");
        }
    };
    $(window).ready(setsidebartype);
    $(window).on("resize", setsidebartype);

});