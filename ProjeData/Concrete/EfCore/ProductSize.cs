using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IProductSizeDalL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class ProductSizeDal : GenericDal<ProductSize>, IProductSizeDal
    {
        public List<ProductSize> ProductSizeGet(int id)
        {
            using (var context = new ProjeContext())
            {
                return context.ProductSizes
                                .Where(i => i.ProductId == id).OrderBy(i => i.Size.SizeSort)
                                // .Include(i => i.Product)
                                .Include(i => i.Size)
                                .ToList();
            }
        }
    }
}