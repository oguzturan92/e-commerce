

var filterTitles = document.querySelectorAll(".favorite-box-title");
var titleImgs = document.querySelectorAll(".favorite-title-img");

addEventListener("load", function () {
    for (let a of filterTitles) {
        var tablo = a.nextElementSibling;
        tablo.style.maxHeight = 0 + "px";
    }
});

for (let a of filterTitles) {
    a.addEventListener("click", function() {

        var tablo = this.nextElementSibling; // İçindeki değil, altındaki eleman
        var i = this.children[1]; // içindeki 1'inci index elemanı
        var img = this.children[1].children[1];
        
        if (tablo.style.maxHeight != "0px" || img.getAttribute("src") == "/img/img-icon-sabit/minus.png") {
            tablo.style.maxHeight = "0px";
            img.setAttribute("src", "/img/img-icon-sabit/plus.png")
        } else {
            tablo.style.maxHeight = tablo.scrollHeight + "px";
            img.setAttribute("src", "/img/img-icon-sabit/minus.png")
        }
    })
}