var sliderContainer = document.querySelector("#slider-container");
var carousel = document.querySelector(".slider-carousel");
var left = document.querySelector("#slider-left");
var right = document.querySelector("#slider-right");
var sliderImages = document.querySelectorAll(".slider-a");
var sliderTime = sliderContainer.getAttribute("value");

var h2 = document.querySelectorAll(".slider-content h2");
var p = document.querySelectorAll(".slider-content p");
var a = document.querySelectorAll(".slider-content a");

var i = 0;
var leftPx = 0;
var interval;
var openWidth = window.innerWidth;

showSlide();

var ePageX;
var prevScrollLeft;
let positionDiff;
var drag = false;
var dragStart1 = false;

window.addEventListener("load", function() {
    h2[0].style.animationName = "h2";
    p[0].style.animationName = "p";
    a[0].style.animationName = "a";
})

const dragStart = (e) => {
    clearInterval(interval);

    dragStart1 = true;
    ePageX = e.pageX || e.touches[0].pageX;
    prevScrollLeft = leftPx;
}

const dragging = (e) => {
    if (!dragStart1) return;
    for(let a of sliderImages) {
        a.style.pointerEvents = "none";
    }
    e.preventDefault();
    drag = true;
    
    positionDiff = (e.pageX || e.touches[0].pageX) - ePageX;
    var leftPx2 = prevScrollLeft - positionDiff;
    leftPx = prevScrollLeft - positionDiff;
    for(let img of sliderImages) {
        img.style.left = "-" + leftPx2 + "px";
        img.style.transition = "none";
    }
}

const dragStop = (e) => {
    for(let a of sliderImages) {
        a.style.pointerEvents = "auto";
    }
    showSlide();
    dragStart1 = false;
    
    for(let img of sliderImages) {
        img.style.transition = ".7s";
    }
    
    if (positionDiff > 0) {
        openWidth = window.innerWidth;
        if (leftPx != 0)
        {
            i--
            leftPx = (openWidth * i)
        }
        for(let img of sliderImages) {
            img.style.left = "-" + leftPx + "px";
        }
    }
    if (positionDiff < 0) {
        openWidth = window.innerWidth;
        i++
        leftPx = (openWidth * i)
        if (i == imagesCount)
        {
            leftPx = 0;
            i = 0;
        }
        for(let img of sliderImages) {
            img.style.left = "-" + leftPx + "px";
        }
    }
}

carousel.addEventListener("mousedown", dragStart);
carousel.addEventListener("mousemove", dragging);
carousel.addEventListener("mouseup", dragStop);

carousel.addEventListener("touchstart", dragStart);
carousel.addEventListener("touchmove", dragging);
carousel.addEventListener("touchend", dragStop);


if (openWidth > 768)
{
    right.addEventListener("click", function() {
        openWidth = window.innerWidth;
        i++
        leftPx = (openWidth * i)
        if (i == imagesCount)
        {
            leftPx = 0;
            i = 0;
        }
        for(let img of sliderImages) {
            img.style.left = "-" + leftPx + "px";
        }
        h2[i].style.animationName = "h2";
        p[i].style.animationName = "p";
        a[i].style.animationName = "a";
    })
    left.addEventListener("click", function() {
        openWidth = window.innerWidth;
        if (leftPx != 0)
        {
            i--
            leftPx = (openWidth * i)
        }
        for(let img of sliderImages) {
            img.style.left = "-" + leftPx + "px";
        }
    })
    right.addEventListener("mouseenter", function() {
        clearInterval(interval);
    })
    left.addEventListener("mouseenter", function() {
        clearInterval(interval);
    })

    right.addEventListener("mouseleave", function() {
        showSlide();
    })
    left.addEventListener("mouseleave", function() {
        showSlide();
    })
}

if (openWidth < 768)
{
    right.addEventListener("click", function() {
        clearInterval(interval);
        openWidth = window.innerWidth;
        i++
        leftPx = (openWidth * i)
        if (i == imagesCount)
        {
            leftPx = 0;
            i = 0;
        }
        for(let img of sliderImages) {
            img.style.left = "-" + leftPx + "px";
        }
        h2[i].style.animationName = "h2";
        p[i].style.animationName = "p";
        a[i].style.animationName = "a";
        showSlide();
    })
    left.addEventListener("click", function() {
        clearInterval(interval);
        openWidth = window.innerWidth;
        if (leftPx != 0)
        {
            i--
            leftPx = (openWidth * i)
        }
        for(let img of sliderImages) {
            img.style.left = "-" + leftPx + "px";
        }
        showSlide();
    })
}

function showSlide() {
    interval = setInterval(function(){
        openWidth = window.innerWidth;
        i++
        leftPx = (openWidth * i)
        if (i == imagesCount)
        {
            leftPx = 0;
            i = 0;
        }
        for(let img of sliderImages) {
            img.style.left = "-" + leftPx + "px";
        }
        h2[i].style.animationName = "h2";
        p[i].style.animationName = "p";
        a[i].style.animationName = "a";
    }, sliderTime)
}