using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<FooterAlt> kısmındaki FooterAlt adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık FooterAlt değerini alıyor.
    public interface IFooterAltDal : IGenericDal<FooterAlt>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/FOOTERALTDAL dosyasında metotları dolduruyoruz.
        FooterAlt FooterAltDetail(string url);
    }
}