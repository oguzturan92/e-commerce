using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/ISUPPORTDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class SupportDal : GenericDal<Support>, ISupportDal
    {
        public List<Support> SupportsAndLines(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Supports
                                .OrderByDescending(i => i.SupportDateTime)
                                .Where(i => i.ProjeUserId == userId)
                                .Include(i => i.SupportLines
                                    .OrderByDescending(i => i.SupportLineDateTime)
                                )
                                .ToList();
            }
        }

        public List<Support> SupportsAndUsers()
        {
            using (var context = new ProjeContext())
            {
                return context.Supports
                                .OrderByDescending(i => i.SupportDateTime)
                                .Include(i => i.ProjeUser)
                                .ToList();
            }
        }

        public Support SupportAndLines(int id)
        {
            using (var context = new ProjeContext())
            {
                return context.Supports
                                .OrderByDescending(i => i.SupportDateTime)
                                .Where(i => i.SupportId == id)
                                .Include(i => i.SupportLines
                                    .OrderByDescending(i => i.SupportLineDateTime)
                                )
                                .FirstOrDefault();
            }
        }
    }
}