using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<EftHavale> kısmındaki EftHavale adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık EftHavale değerini alıyor.
    public interface IEftHavaleDal : IGenericDal<EftHavale>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/EFHAVALEDAL dosyasında metotları dolduruyoruz.
    }
}