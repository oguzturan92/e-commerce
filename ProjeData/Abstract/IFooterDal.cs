using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Footer> kısmındaki Footer adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Footer değerini alıyor.
    public interface IFooterDal : IGenericDal<Footer>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/FOOTERDAL dosyasında metotları dolduruyoruz.
        List<Footer> FooterAndAltList();
    }
}