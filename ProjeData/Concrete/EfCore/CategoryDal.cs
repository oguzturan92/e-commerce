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
    // ABSTRACT/ICATEGORYDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class CategoryDal : GenericDal<Category>, ICategoryDal
    {
        public Category SeciliKategori(string url)
        {
            using (var context = new ProjeContext())
            {
                var categories = context.Categories.AsQueryable();

                if (!string.IsNullOrEmpty(url))
                {
                    categories = categories
                            .Where(i => i.CategoryUrl.ToLower() == url.ToLower() && i.CategoryApproval);
                }
                return categories.FirstOrDefault();
            }
        }

        public List<Category> CategoryMenu()
        {
            using (var context = new ProjeContext())
            {
                return context.Categories
                                .Where(i => i.CategoryApproval && i.CategoryVisibility == "MenuTrue")
                                .OrderBy(i => i.CategorySort)
                                .Include(i => i.Category2s
                                    .Where(i => i.Category2Approval && i.Category2Visibility == "MenuTrue")
                                    .OrderBy(i => i.Category2Sort)
                                )
                                .ThenInclude(i => i.Category3s
                                    .Where(i => i.Category3Approval && i.Category3Visibility == "MenuTrue")
                                    .OrderBy(i => i.Category3Sort)
                                )
                                .Include(i => i.Category2s)
                                .ToList();
            }
        }

        public List<Category> CategoryIcerikMenu()
        {
            using (var context = new ProjeContext())
            {
                return context.Categories
                                .Where(i => i.CategoryApproval && i.CategoryListType == "Icerik" && i.CategoryVisibility != "Link")
                                .OrderBy(i => i.CategorySort)
                                .Include(i => i.Category2s
                                    .Where(i => i.Category2Approval && i.Category2ListType == "Icerik" && i.Category2Visibility != "Link")
                                    .OrderBy(i => i.Category2Sort)
                                )
                                .ToList();
            }
        }

        public List<Category> AllCategory()
        {
            using (var context = new ProjeContext())
            {
                return context.Categories
                                .Where(i => i.CategoryListType == "Urun")
                                .OrderBy(i => i.CategorySort)
                                .Include(i => i.Category2s
                                    .Where(i => i.Category2ListType == "Urun")
                                    .OrderBy(i => i.Category2Sort)
                                )
                                .ThenInclude(i => i.Category3s
                                    .Where(i => i.Category3ListType == "Urun")
                                    .OrderBy(i => i.Category3Sort)
                                )
                                .ToList();
            }
        }

        public Category CategoryFilters(string url)
        {
            using (var context = new ProjeContext())
            {
                return context.Categories
                                    .OrderBy(i => i.CategorySort)
                                    .Where(i => i.CategoryUrl.ToLower() == url.ToLower() && i.CategoryApproval)
                                    .Include(i => i.Category2s
                                        .Where(i => i.Category2Approval)
                                        .OrderBy(a => a.Category2Sort)
                                    )
                                    .ThenInclude(i => i.Category3s
                                        .Where(i => i.Category3Approval)
                                        .OrderBy(a => a.Category3Sort)
                                    )
                                    .FirstOrDefault();
            }
        }

    }
}