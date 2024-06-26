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
    // ABSTRACT/ICATEGORY3DAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class Category3Dal : GenericDal<Category3>, ICategory3Dal
    {
        public Category3 SeciliKategori3(string url) // Seçilen kategorinin, adı açıklaması, resim bilgisini getirir.
        {
            using (var context = new ProjeContext())
            {
                var categories = context.Category3s.AsQueryable();

                if (!string.IsNullOrEmpty(url))
                {
                    categories = categories
                            .Where(i => i.Category3Url.ToLower() == url.ToLower() && i.Category3Approval)
                            .Include(i => i.Category2.Category);
                }
                return categories.FirstOrDefault();
            }
        }
    
        public Category3 CategoryFilters3(string url)
        {
            using (var context = new ProjeContext())
            {
                return context.Category3s
                                    .Where(i => i.Category3Url.ToLower() == url.ToLower() && i.Category3Approval)
                                    .FirstOrDefault();
            }
        }

    }
}