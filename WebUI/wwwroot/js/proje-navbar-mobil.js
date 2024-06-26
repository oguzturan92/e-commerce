
// NAVBARI AÇMA KAPATMA İŞLEVİ
var checkbox = document.querySelector("#checkbox");
var menu = document.querySelector("#menu");
var onOff = document.querySelector("#onOff");
var bgJsOpacity = document.querySelector("#bg-js-opacity");
checkbox.addEventListener("click", function() {
    if (checkbox.checked) {
        menu.style.right = "0px";
        // onOff.style.position = "fixed";
        menu.style.boxShadow = "-20px 0px 20px 0px #0000001a";
        bgJsOpacity.style.display = "block";
        bgJsOpacity.addEventListener("click", function() { // main'e tıklandığında menüyü kapatır
            checkbox.checked = false;
            menu.style.right = "-300px";
            // onOff.style.position = "absolute";
            menu.style.boxShadow = "none";
            bgJsOpacity.style.display = "none";
        })
    } else {
        menu.style.right = "-300px";
        // onOff.style.position = "absolute";
        menu.style.boxShadow = "none";
        bgJsOpacity.style.display = "none";
    }
})

// KATEGORİ AÇMA KAPATMA İŞLEVİ
var mobilUps = document.querySelectorAll(".mobil-up");

for (let a of mobilUps) {
    a.addEventListener("click", function() {
        var blogUl2 = a.nextElementSibling;
        
        if (blogUl2.style.display != "block") {
            blogUl2.style.display = "block";
            a.style.transform = "rotate(0deg)";
        } else {
            blogUl2.style.display = "none";
            a.style.transform = "rotate(-180deg)";
        }
    })
}