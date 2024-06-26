using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Adres> kısmındaki Adres adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Adres değerini alıyor.
    public interface IAdresDal : IGenericDal<Adres>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/ADRESDAL dosyasında metotları dolduruyoruz.
    }
}