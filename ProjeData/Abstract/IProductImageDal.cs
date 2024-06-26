using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<ProductImage> kısmındaki ProductImage adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık ProductImage değerini alıyor.
    public interface IProductImageDal : IGenericDal<ProductImage>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/PRODUCTIMAGEDAL dosyasında metotları dolduruyoruz.
    }
}