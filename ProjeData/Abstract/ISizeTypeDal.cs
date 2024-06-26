using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<SizeType> kısmındaki SizeType adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık SizeType değerini alıyor.
    public interface ISizeTypeDal : IGenericDal<SizeType>
    {
        // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/SIZETYPEDAL dosyasında metotları dolduruyoruz.
        List<SizeType> SizeTypeAndSize();
        SizeType ProductDetailSize(int id);
        List<SizeType> SizeTypeAndSizeFilters(string url);
        List<SizeType> SizeTypeAndSizeFilters2(string url);
        List<SizeType> SizeTypeAndSizeFilters3(string url);
    }
}