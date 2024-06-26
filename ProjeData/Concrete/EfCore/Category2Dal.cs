using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete
{
    // ABSTRACT/ICATEGORY2DAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class Category2Dal : GenericDal<Category2>, ICategory2Dal
    {
        public Category2 SeciliKategori2(string url) // Seçilen kategorinin, adı açıklaması, resim bilgisini getirir.
        {
            using (var context = new ProjeContext())
            {
                var categories = context.Category2s.AsQueryable();

                if (!string.IsNullOrEmpty(url))
                {
                    categories = categories
                            .Where(i => i.Category2Url.ToLower() == url.ToLower() && i.Category2Approval);
                }
                return categories.FirstOrDefault();
            }
        }

        public Category2 CategoryFilters2(string url)
        {
            using (var context = new ProjeContext())
            {
                return context.Category2s
                                    .OrderBy(i => i.Category2Sort)
                                    .Where(i => i.Category2Url.ToLower() == url.ToLower() && i.Category2Approval)
                                    .Include(i => i.Category)
                                    .Include(i => i.Category3s
                                        .Where(i => i.Category3Approval)
                                        .OrderBy(a => a.Category3Sort)
                                    )
                                    .FirstOrDefault();
            }
        }

    }
}