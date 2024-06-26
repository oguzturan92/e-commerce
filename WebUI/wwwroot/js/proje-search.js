

var searchBox = document.querySelector("#search-box");
var searchClose = document.querySelector("#search-box-close");
var searchForm = document.querySelector("#search-form");

searchForm.addEventListener("click", function() {
    searchBox.style.display = "flex";
    searchClose.style.display = "flex";
})

searchClose.addEventListener("click", function() {
    searchBox.style.display = "none";
    searchClose.style.display = "none";
})


var searchBoxMobil = document.querySelector("#search-box-mobil");
var searchCloseMobil = document.querySelector("#search-box-close-mobil");
var searchFormMobil = document.querySelector("#search-form-mobil");

searchFormMobil.addEventListener("click", function() {
    searchBoxMobil.style.display = "flex";
    searchCloseMobil.style.display = "flex";
})

searchCloseMobil.addEventListener("click", function() {
    searchBoxMobil.style.display = "none";
    searchCloseMobil.style.display = "none";
})