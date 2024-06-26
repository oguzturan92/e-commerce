using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Size> kısmındaki ProductSize adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Size değerini alıyor.
    public interface ISizeDal : IGenericDal<Size>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/SIZEDAL dosyasında metotları dolduruyoruz.
    }
}