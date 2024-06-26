using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IADRESDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class AdresDal : GenericDal<Adres>, IAdresDal
    {
        
    }
}