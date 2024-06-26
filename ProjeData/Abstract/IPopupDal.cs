using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Popup> kısmındaki About adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Popup değerini alıyor.
    public interface IPopupDal : IGenericDal<Popup>
    {
        // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/POPUPDAL dosyasında metotları dolduruyoruz.
    }
}