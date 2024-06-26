using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<MailAbone> kısmındaki MailAbone adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık MailAbone değerini alıyor.
    public interface ISubscribeDal : IGenericDal<Subscribe>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/MAILABONEDAL dosyasında metotları dolduruyoruz.
        
    }
}