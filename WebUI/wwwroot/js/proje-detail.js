

// QUANTİTY ---------------------------------------
var down = document.querySelector("#quantity-down");
var up = document.querySelector("#quantity-up");

down.addEventListener("click", function () {
    var quantity = document.querySelector("#quantity").value;
    if (quantity > 1) {
        var qty = quantity - 1;
        document.querySelector("#quantity").value = qty;
    }
});

up.addEventListener("click", function () {
    var quantity = document.querySelector("#quantity").value;
    var qty = parseInt(quantity) + 1;
    document.querySelector("#quantity").value = qty;
});

// DESCRIPTION ---------------------------------------
var boxA = document.querySelectorAll(".product-detail-description-box-a");
var boxP = document.querySelectorAll(".product-detail-description-box-p");

addEventListener("load", function () {
    boxA[0].style.borderBottom = "5px solid #c2a18a";
    boxP[0].style.display = "block";
});
for (let a of boxA) {
    a.addEventListener("click", function() {
        for (let a of boxA) {
            if (a.style.borderBottom == "5px solid rgb(194, 161, 138)") {
                a.style.borderBottom = "5px solid #ffffff00"
            }
        }
        a.style.borderBottom = "5px solid #c2a18a"

        var clickId = a.getAttribute("id");
        for (let p of boxP) {
            if (p.getAttribute("id") == clickId) {
                p.style.display = "block";
            } else {
                p.style.display = "none";
            }
        }
    })
}


