$(".preloader").delay(1000).fadeOut();

var loveDress = document.querySelectorAll(".pannel-hot-dress > ul li:nth-child(2) a i")
loveDress.forEach((e) => {
    e.addEventListener("click", function () {
        if (e.classList.contains("fa-heart") && e.classList.contains("fa-regular")) {
            e.classList.remove("fa-heart")
            e.classList.remove("fa-regular")
            e.style.color = "red";
            e.classList.add("fa-solid")
            e.classList.add("fa-heart")
        }
        else {
            e.classList.remove("fa-solid")
            e.classList.remove("fa-heart")
            e.style.color = "black";
            e.classList.add("fa-regular")
            e.classList.add("fa-heart")
        }
    })
})

// croll to element
function reveal() {
    var reveals = document.querySelectorAll(".reveal");

    for (var i = 0; i < reveals.length; i++) {
        var windowHeight = window.innerHeight;
        var elementTop = reveals[i].getBoundingClientRect().top;
        var elementVisible = 140;

        if (elementTop < windowHeight - elementVisible) {
            reveals[i].classList.add("active-ani");
        } else {
            reveals[i].classList.remove("active-ani");
        }
    }
}

window.addEventListener("scroll", reveal);

//load number when croll to this
$(window).scroll(testScroll);
var viewed = false;

function isScrolledIntoView(elem) {
    if (elem != null) {
        var docViewTop = $(window).scrollTop();

        var elemTop = $(elem).offset().top;
        var elemBottom = elemTop + $(elem).height();
    }
    return ((elemTop <= docViewTop + $(window).height()));
}

function testScroll() {
    if ($(".numbers") != null && isScrolledIntoView($(".numbers")) && !viewed) {
        viewed = true;
        $('.value').each(function () {
            $(this).prop('Counter', 0).animate({
                Counter: $(this).text()
            }, {
                duration: 4000,
                easing: 'swing',
                step: function (now) {
                    $(this).text(Math.ceil(now));
                }
            });
        });
    }
}

// croll to top
let mybutton = document.getElementById("crollToTop");
$(window).scroll(scrollFunctionToHead)

mybutton.addEventListener("click", () => {
    topFunction()
})
function scrollFunctionToHead() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
// pin navbar when croll
$(window).scroll( function () { scrollFunction() });
document.querySelectorAll(".nav-item a").forEach((e) => {
    e.style.color = "white";
    e.style.textShadow = "none";        
})  

function scrollFunction() {
    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
        document.getElementById("navigate").style.padding = "0";
        document.getElementById("logo").style.width = "60px";
        document.getElementById("navigate").style.backgroundColor = "white";
        document.getElementById("navigate").style.boxShadow = "0px 2px 10px #ededed";
        document.querySelectorAll(".nav-item a").forEach((e) => {
            e.style.color = "black";
            e.style.textShadow = "none";        
        })        
    } else {
        document.getElementById("logo").style.width = "100px";
        document.getElementById("navigate").style.padding = "0px";
        document.querySelector("#logo a img").style.height = "100px";
        document.getElementById("navigate").style.backgroundColor = "transparent";
        document.getElementById("navigate").style.boxShadow = "none";
        document.querySelectorAll(".nav-item a").forEach((e) => {
            e.style.color = "white";
            e.style.textShadow = "0px 0px 10px #6a6a6a";
        })
    }
}

// js for carousel feed back
const swiper = new Swiper(".Myswiper", {
    // Optional parameters
    loop: true,
    autoplay: {
        delay: 3000,
        disableOnInteraction: false,
        pauseOnMouseEnter: true
    },
    rewind: true,
    // Navigation arrows
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});

var swiperHotDress = new Swiper(".SwiperDetailsHotDress", {
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    }
});

// toggle menu mobile
var btnOpenMenuMobile = document.getElementById("iconMenuMobile")
var iconMenuMobile = document.querySelector("#iconMenuMobile>i")
var contentmenuMobile = document.getElementById("contentMenuMobile")
var divMenuMobile = document.getElementById("menuForMobile")
btnOpenMenuMobile.addEventListener("click",()=>{
    if(iconMenuMobile.classList.contains("fa-bars")){
        iconMenuMobile.classList.remove("fa-bars")
        iconMenuMobile.classList.add("fa-xmark")
        divMenuMobile.style.transform = "translateX(0)"
    }
    else
    {
        iconMenuMobile.classList.remove("fa-xmark")
        iconMenuMobile.classList.add("fa-bars")
        divMenuMobile.style.transform = "translateX(1500px)"
    }
})

// box details dress
var btnCloseBoxDetails = document.querySelector("#closeBoxDetails i")
var boxDetails = document.getElementById("boxDetailsDressContainer")
var btnEyeSeeDetails = document.querySelectorAll("#hot-dress .none-liststyle li:nth-child(4) i")

btnCloseBoxDetails.addEventListener("click", ()=>{
    boxDetails.style.display = "none"
})

btnEyeSeeDetails.forEach((e)=>{
    e.addEventListener("click", ()=>{
        boxDetails.style.display = "flex"
    })
})

