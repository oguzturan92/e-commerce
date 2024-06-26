using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IFOOTERALTDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class FooterAltDal : GenericDal<FooterAlt>, IFooterAltDal
    {
        public FooterAlt FooterAltDetail(string url)
        {
            using (var context = new ProjeContext())
            {
                return context.FooterAlts
                                .Where(i => i.FooterAltLink == url)
                                .FirstOrDefault();
            }
        }
    }
}