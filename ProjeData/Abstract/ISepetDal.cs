using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Sepet> kısmındaki Sepet adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Sepet değerini alıyor.
    public interface ISepetDal : IGenericDal<Sepet>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/SEPETDAL dosyasında metotları dolduruyoruz.
        Sepet SepetAndProducts(int userId);
        Sepet Sepet(int userId);
        Sepet SepetAndProductsIncomplete(int id);
        List<Sepet> SepetsAndUserIncomplete();

    }
}