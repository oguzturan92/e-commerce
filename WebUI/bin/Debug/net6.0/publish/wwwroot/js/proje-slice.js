
var mediaQuery = window.matchMedia("(min-width: 768px)")
var elemanlar = document.querySelectorAll(".slice-100-50"); // Class adı blog-random-h olan tüm elemanlara ulaşır.
for(let eleman of elemanlar) { // Ulaştığı listeyi parçalar
    if (mediaQuery.matches)
    {
        var sonuc = eleman.innerHTML.slice(0, 20); // Her birine slice metodunu uygulayıp
        if (sonuc.length > 19) { // Yazdırılacak metin slice uzunluğu 19'dan büyükse 3 nokta koyar, değilse koymaz
            eleman.innerHTML = sonuc + "...";
        } else {
            eleman.innerHTML = sonuc;
        }
    } else
    {
        var sonuc = eleman.innerHTML.slice(0, 20); // Her birine slice metodunu uygulayıp
        if (sonuc.length > 19) { // Yazdırılacak metin slice uzunluğu 19'dan büyükse 3 nokta koyar, değilse koymaz
            eleman.innerHTML = sonuc + "...";
        } else {
            eleman.innerHTML = sonuc;
        }
    }
}

var slice30 = document.querySelectorAll(".slice-30");
for(let item of slice30) {
        var sonuc = item.innerHTML.slice(0, 15); // Her birine slice metodunu uygulayıp
        if (sonuc.length > 14) { // Yazdırılacak metin slice uzunluğu 19'dan büyükse 3 nokta koyar, değilse koymaz
            item.innerHTML = sonuc + "...";
        } else {
            item.innerHTML = sonuc;
        }
}