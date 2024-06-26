using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Mesaj> kısmındaki Mesaj adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Mesaj değerini alıyor.
    public interface IMessageDal : IGenericDal<Message>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/MESAJ dosyasında metotları dolduruyoruz.
        
    }
}