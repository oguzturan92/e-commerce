

var orderTitle = document.querySelectorAll(".support-list-item-title");

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


// Form aç - kapa
var supportForm = document.querySelector(".support-new-container");
var newFormBtn = document.querySelector("#new-support-button");
var cancelButton = document.querySelector("#cancel-support-button");

newFormBtn.addEventListener("click", function () {
    supportForm.style.display = "block";
    newFormBtn.style.display = "none";
})

cancelButton.addEventListener("click", function () {
    supportForm.style.display = "none";
    newFormBtn.style.display = "block";
})
