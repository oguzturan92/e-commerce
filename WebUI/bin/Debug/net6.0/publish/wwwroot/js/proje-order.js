

var orderTitle = document.querySelectorAll(".order-list-item-title");

addEventListener("load", function () {
    for (let a of orderTitle) {
        var tablo = a.nextElementSibling;
        tablo.style.maxHeight = "0px";
    }
});

for (let a of orderTitle) {
    a.addEventListener("click", function() {
        var tablo = this.nextElementSibling;
        if (tablo.style.maxHeight == "0px") {
            tablo.style.maxHeight = tablo.scrollHeight + "px";
        } else {
            tablo.style.maxHeight = "0px";
        }
    })
}