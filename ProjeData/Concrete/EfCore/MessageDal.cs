using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete
{
    // ABSTRACT/IMESAJDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class MessageDal : GenericDal<Message>, IMessageDal
    {
        
    }
}