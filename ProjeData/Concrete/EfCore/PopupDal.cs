using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete
{
    // ABSTRACT/IPOPUPDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class PopupDal : GenericDal<Popup>, IPopupDal
    {
        
    }
}