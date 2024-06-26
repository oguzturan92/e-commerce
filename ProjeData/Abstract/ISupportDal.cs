using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Support> kısmındaki Support adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Support değerini alıyor.
    public interface ISupportDal : IGenericDal<Support>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/SUPPORTDAL dosyasında metotları dolduruyoruz.
        List<Support> SupportsAndLines(int userId);
        List<Support> SupportsAndUsers();
        Support SupportAndLines(int id);
    }
}