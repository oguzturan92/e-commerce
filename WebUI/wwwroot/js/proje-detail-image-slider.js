


var imageCount = document.querySelector("#image-count").getAttribute("value");
var leftBtn = document.querySelector("#product-detail-img-left");
var rightBtn = document.querySelector("#product-detail-img-right");
var styleImgsLeft = document.querySelector("#product-detail-imgs");
var imgBox = document.querySelector("#product-detail-img-2-alt");
var imgBoxWidth = imgBox.clientWidth;
var leftPx = 0;

rightBtn.addEventListener("click", function() {
    var maxPx = (imageCount * 80) - 1;

    leftPx = leftPx - 80;
    if (leftPx > -maxPx) {
        styleImgsLeft.style.left = leftPx + "px";
    } else {
        leftPx = 0;
        styleImgsLeft.style.left = 0 + "px";
    }

})

leftBtn.addEventListener("click", function() {
    var maxPx = (imageCount * 80) - 80;
    
    if (leftPx < 0) {
        leftPx = leftPx + 80;
        styleImgsLeft.style.left = leftPx + "px";
    } else {
        leftPx = leftPx - maxPx;
        styleImgsLeft.style.left = -maxPx + "px";
    }

})




var anaImg = document.querySelector("#product-detail-img-1 img");
var altImgs = document.querySelectorAll(".product-detail-imgs-2");
var zoomAnaImg = document.querySelector("#product-img-zoom-img img");

for (let a of altImgs) {
    a.addEventListener("click", function() {
        var value = a.getAttribute("src");
        anaImg.setAttribute("src", value);
        zoomAnaImg.setAttribute("src", value);
    })
}


// OPEN IMG ------------------------------------------------------

var zoomBox = document.querySelector("#product-img-zoom-box");
var zoomCloseBtn = document.querySelector("#product-img-zoom-close");
var zoomImgLeft = document.querySelector("#product-img-zoom-left");
var zoomImgRight = document.querySelector("#product-img-zoom-right");


zoomCloseBtn.addEventListener("click", function() {
    zoomBox.style.display = "none";
    zoomAnaImg.style.zoom = "1"
})

anaImg.addEventListener("click", function() {
    zoomBox.style.display = "block";
})

zoomAnaImg.addEventListener("click", function() {
    if (zoomAnaImg.style.zoom == "2") {
        zoomAnaImg.style.zoom = "1"
    } else {
        zoomAnaImg.style.zoom = "2"
    }
})

var images = document.querySelectorAll(".product-detail-imgs-2");
var index = 0;

zoomImgLeft.addEventListener("click", function() {

    if (index == 0)
    {
        index = imageCount
    }
    index--;
    zoomAnaImg.setAttribute("src", images[index].src);

})
zoomImgRight.addEventListener("click", function() {

    if (index == imageCount - 1)
    {
        index = -1
    }
    index++;
    zoomAnaImg.setAttribute("src", images[index].src);

})