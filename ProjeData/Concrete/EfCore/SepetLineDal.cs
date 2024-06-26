using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/ISEPETLINEDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class SepetLineDal : GenericDal<SepetLine>, ISepetLineDal
    {
        public SepetLine SepetLineAndProduct(int id)
        {
            using (var context = new ProjeContext())
            {
                return context.SepetLines
                                .Where(i => i.SepetLineId == id)
                                .Include(i => i.Product)
                                .FirstOrDefault();
            }
        }

        public SepetLine SepetLineAndProductAndSize(int proId, int proSizeId)
        {
            using (var context = new ProjeContext())
            {
                return context.SepetLines
                                .Where(i => i.SepetLineId == proId)
                                .Include(i => i.Product)
                                .ThenInclude(i => i.ProductSizes.Where(i => i.ProductSizeId == proSizeId))
                                .FirstOrDefault();
            }
        }
    }
    
}