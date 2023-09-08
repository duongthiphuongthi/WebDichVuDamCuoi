$(".preloader").delay(1000).fadeOut();

// love dress icon
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


// price input
const rangeInput = document.querySelectorAll(".range-input input"),
    priceInput = document.querySelectorAll(".price-input input"),
    range = document.querySelector(".slider .progress");
let priceGap = 1000;
priceInput.forEach(input => {
    input.addEventListener("input", e => {
        let minPrice = parseInt(priceInput[0].value),
            maxPrice = parseInt(priceInput[1].value);

        if ((maxPrice - minPrice >= priceGap) && maxPrice <= rangeInput[1].max) {
            if (e.target.className === "input-min") {
                rangeInput[0].value = minPrice;
                range.style.left = ((minPrice / rangeInput[0].max) * 100) + "%";
            } else {
                rangeInput[1].value = maxPrice;
                range.style.right = 100 - (maxPrice / rangeInput[1].max) * 100 + "%";
            }
        }
    });
});
rangeInput.forEach(input => {
    input.addEventListener("input", e => {
        let minVal = parseInt(rangeInput[0].value),
            maxVal = parseInt(rangeInput[1].value);
        if ((maxVal - minVal) < priceGap) {
            if (e.target.className === "range-min") {
                rangeInput[0].value = maxVal - priceGap
            } else {
                rangeInput[1].value = minVal + priceGap;
            }
        } else {
            priceInput[0].value = minVal;
            priceInput[1].value = maxVal;
            range.style.left = ((minVal / rangeInput[0].max) * 100) + "%";
            range.style.right = 100 - (maxVal / rangeInput[1].max) * 100 + "%";
        }
    });
});

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
$(window).scroll(function () { scrollFunction() });
document.querySelectorAll(".nav-item a").forEach((e) => {
    e.style.color = "white";
    e.style.textShadow = "none";
})

function scrollFunction() {
    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
        document.getElementById("navigate").style.padding = "0";
        document.getElementById("logo").style.width = "60px";
        document.getElementById("navigate").style.backgroundColor = "white";
        document.querySelectorAll(".nav-item a").forEach((e) => {
            e.style.color = "black";
            e.style.textShadow = "none";
        })
    } else {
        document.getElementById("logo").style.width = "100px";
        document.getElementById("navigate").style.padding = "0px";
        document.querySelector("#logo a img").style.height = "100px";
        document.getElementById("navigate").style.backgroundColor = "transparent";
        document.querySelectorAll(".nav-item a").forEach((e) => {
            e.style.color = "white";
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
    zoom: true,
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
btnOpenMenuMobile.addEventListener("click", () => {
    if (iconMenuMobile.classList.contains("fa-bars")) {
        iconMenuMobile.classList.remove("fa-bars")
        iconMenuMobile.classList.add("fa-xmark")
        divMenuMobile.style.transform = "translateX(0)"
    }
    else {
        iconMenuMobile.classList.remove("fa-xmark")
        iconMenuMobile.classList.add("fa-bars")
        divMenuMobile.style.transform = "translateX(1500px)"
    }
})

// box details dress
var btnCloseBoxDetails = document.querySelector("#closeBoxDetails i")
var boxDetails = document.getElementById("boxDetailsDressContainer")
var btnEyeSeeDetails = document.querySelectorAll("#hot-dress .none-liststyle li:nth-child(4) i")

btnCloseBoxDetails.addEventListener("click", () => {
    boxDetails.style.display = "none"
})

btnEyeSeeDetails.forEach((e) => {
    e.addEventListener("click", () => {
        boxDetails.style.display = "flex"
    })
})

