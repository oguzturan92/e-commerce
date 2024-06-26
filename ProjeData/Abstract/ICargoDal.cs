using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Cargo> kısmındaki Cargo adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Cargo değerini alıyor.
    public interface ICargoDal : IGenericDal<Cargo>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/CARGODAL dosyasında metotları dolduruyoruz.
    }
}