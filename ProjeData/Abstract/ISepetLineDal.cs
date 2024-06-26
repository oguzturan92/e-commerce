using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<SepetLine> kısmındaki Sepet adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Sepet değerini alıyor.
    public interface ISepetLineDal : IGenericDal<SepetLine>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/SEPETLINEDAL dosyasında metotları dolduruyoruz.
        SepetLine SepetLineAndProduct(int id);
        SepetLine SepetLineAndProductAndSize(int proId, int proSizeId);
    }
}