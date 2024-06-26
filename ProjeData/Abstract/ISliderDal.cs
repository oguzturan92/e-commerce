using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Slider> kısmındaki Slider adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Slider değerini alıyor.
    public interface ISliderDal : IGenericDal<Slider>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/SLIDERDAL dosyasında metotları dolduruyoruz.
    }
}