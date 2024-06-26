// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// MENÜ ELEMANLARINA ACTİVE CLASS EKLEME
$(document).ready(function(){ // Sayfa açıldığında
    var url = document.location.pathname; // url yolunu aldık
    var adminNavLiA = document.querySelectorAll("#admin-nav-ul li a"); // hedef elemanları aldık
    var admiNilkAelemani = document.querySelector("#admin-nav-ul").children[0].children[0]; // parantez içindeki elemanın altındaki 1'inci index elemanının altındaki 0'ıncı index. Yani ul altındaki li altındaki a etiketine ulaştık.
    for(let a of adminNavLiA) { // hedef elemanları tek tek ayırdık
        var navbar = a.getAttribute("href"); // a elemanının href bilgisini aldık
        
        if (url.includes(navbar)) { // o anki url içinde navbar değişkeni içindeki isim varsa
            a.className = "admin-nav-active";
            admiNilkAelemani.className = "";
        } else {
            a.className = "";
        }
        
    }
});