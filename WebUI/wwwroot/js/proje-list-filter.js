

var filterTitles = document.querySelectorAll(".filter-box-title");

addEventListener("load", function () {
    for (let a of filterTitles) {
        var tablo = a.nextElementSibling;
        tablo.style.maxHeight = tablo.scrollHeight + "px";
    }
});

for (let a of filterTitles) {
    a.addEventListener("click", function() {

        var tablo = this.nextElementSibling; // Tıkladığımız elemanın altındaki elemana ulaştık.
        var i = this.children[1]; // Tıkladığımız elemanın içindeki elemanların 1'inci index elemanına ulaştık.
        
        // css max-height özelliği false ise, scroll height rakamını, css max-height değerine atar.
        // css max-height özelliği true ise, css max-height değerini null yapar.
        if (tablo.style.maxHeight != "0px") {
            tablo.style.maxHeight = "0px";
            i.style.transform = "rotate(0deg)";
        } else {
            tablo.style.maxHeight = tablo.scrollHeight + "px";
            i.style.transform = "rotate(180deg)";
        }
    })
}


// var form = document.querySelector("#filterForm");
// var labels = document.querySelectorAll(".filterFormLabel");
// for (let label of labels) {
//     label.addEventListener("click", function() {
//         setInterval(function() {
//             form.submit();
//         }, 50);
//     })
// }