using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IFOOTERDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class FooterDal : GenericDal<Footer>, IFooterDal
    {
        public List<Footer> FooterAndAltList()
        {
            using (var context = new ProjeContext())
            {
                return context.Footers
                                .Where(i => i.FooterApproval)
                                .OrderBy(i => i.FooterSort)
                                .Include(i => i.FooterAlts
                                    .Where(i => i.FooterAltApproval)
                                    .OrderBy(i => i.FooterAltSort)
                                )
                                .ToList();
            }
        }
    }
}