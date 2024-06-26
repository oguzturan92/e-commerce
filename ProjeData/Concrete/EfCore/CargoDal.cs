using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/ICARGODAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class CargoDal : GenericDal<Cargo>, ICargoDal
    {
        
    }
}