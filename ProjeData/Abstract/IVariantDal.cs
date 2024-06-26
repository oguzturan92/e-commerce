using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Variant> kısmındaki Variant adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Variant değerini alıyor.
    public interface IVariantDal : IGenericDal<Variant>
    {
        // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/VARIANTDAL dosyasında metotları dolduruyoruz.
    }
}