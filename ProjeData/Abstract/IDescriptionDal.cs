using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Description> kısmındaki Description adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Description değerini alıyor.
    public interface IDescriptionDal : IGenericDal<Description>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/DESCRIPTIONDAL dosyasında metotları dolduruyoruz.
    }
}