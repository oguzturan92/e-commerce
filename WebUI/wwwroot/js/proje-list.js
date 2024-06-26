

var productList = document.querySelector(".product-list");
var productList1 = document.querySelector("#product-list-line-1");
var productList2 = document.querySelector("#product-list-line-2");
var productList3 = document.querySelector("#product-list-line-3");
var productList4 = document.querySelector("#product-list-line-4");

productList1.addEventListener("click", function() {
    productList.style.gridTemplateColumns = "repeat(1, 1fr)";
})

productList2.addEventListener("click", function() {
    productList.style.gridTemplateColumns = "repeat(2, 1fr)";
})

productList3.addEventListener("click", function() {
    productList.style.gridTemplateColumns = "repeat(3, 1fr)";
})

productList4.addEventListener("click", function() {
    productList.style.gridTemplateColumns = "repeat(4, 1fr)";
})


// FILTERS
var productListFilters = document.querySelector(".product-list-filters");
var productListFilterBtn = document.querySelector("#product-list-line-filter-img");
var productListContainer = document.querySelector("#product-list-container");
var mediaQuery = window.matchMedia("(min-width: 1000px)");
var w = $(window). width(); 

productListFilterBtn.addEventListener("click", function() {
    if (w > 1000) {
        if (productListFilters.style.width == "0px") {
            productListFilters.style.width = "300px";
            productListFilters.style.opacity = "1";
            productListContainer.style.gap = "10px";
            
        } else{
            productListFilters.style.width = "0px";
            productListFilters.style.opacity = "0";
            productListContainer.style.gap = "0px";
        }
    } else
    {
        if (productListFilters.style.height == "auto") {
            productListFilters.style.height = "0px";
            productListFilters.style.opacity = "0";
            productListContainer.style.gap = "0px";
            
        } else{
            productListFilters.style.height = "auto";
            productListFilters.style.opacity = "1";
            productListContainer.style.gap = "10px";
        }
    }
})