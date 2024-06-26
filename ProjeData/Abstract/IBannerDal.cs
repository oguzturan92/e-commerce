using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Banner> kısmındaki Banner adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Banner değerini alıyor.
    public interface IBannerDal : IGenericDal<Banner>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/BANNERDAL dosyasında metotları dolduruyoruz.
    }
}