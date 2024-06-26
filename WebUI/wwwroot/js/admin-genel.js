


// ALERT SİLME İŞLEMİ
function silOnayla()
{
    return confirm("Bu işlem geri ALINAMAZ. Devam etmek istediğinize emin misiniz?");
}


var elemanlar = document.getElementsByClassName("slice"); // Class adı blog-random-h olan tüm elemanlara ulaşır.
for(let eleman of elemanlar) { // Ulaştığı listeyi parçalar
    var sonuc = eleman.innerHTML.slice(0, 35); // Her birine slice metodunu uygulayıp
    if (sonuc.length > 34) { // Yazdırılacak metin slice uzunluğu 19'dan büyükse 3 nokta koyar, değilse koymaz
        eleman.innerHTML = sonuc + "...";
    } else {
        eleman.innerHTML = sonuc;
    }
}