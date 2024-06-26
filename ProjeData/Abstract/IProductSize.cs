using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<ProductSize> kısmındaki ProductSize adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık ProductSize değerini alıyor.
    public interface IProductSizeDal : IGenericDal<ProductSize>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/PRODUCTSIZEDAL dosyasında metotları dolduruyoruz.
        List<ProductSize> ProductSizeGet(int id);
    }
}