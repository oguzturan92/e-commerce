
// NAVBARI AÇMA KAPATMA İŞLEVİ
var checkbox = document.querySelector("#checkbox");
var menu = document.querySelector("#menu");
var ul1 = document.querySelector(".ul-1");
var bgJsOpacity = document.querySelector("#bg-js-opacity"); // Menü açıldığında arka plan siyah saydam alan
checkbox.addEventListener("click", function() {
    if (checkbox.checked) {
        menu.style.top = "0px";        
        ul1.style.boxShadow = "0px 20px 20px 0px #0000001a";
        bgJsOpacity.style.display = "block";
        bgJsOpacity.addEventListener("click", function() { // main'e tıklandığında menüyü kapatır
            checkbox.checked = false;
            menu.style.top = "-1250px";        
            ul1.style.boxShadow = "none";
            bgJsOpacity.style.display = "none";
        })
    } else {
        menu.style.top = "-1250px";        
        ul1.style.boxShadow = "none";
        bgJsOpacity.style.display = "none";
    }
})